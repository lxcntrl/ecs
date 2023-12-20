using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine.SceneManagement;

public partial class SceneLoadingSystem : SystemBase {

    protected override void OnUpdate() {
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        foreach (var (loadScene, entity) in SystemAPI.Query<RefRO<LoadSceneData>>().WithEntityAccess().WithNone<LoadSceneProcess>()) {

            var scene = RuntimeContentManager.LoadSceneAsync(loadScene.ValueRO.SceneReference.Id,
                    new Unity.Loading.ContentSceneParameters {
                        loadSceneMode = LoadSceneMode.Single
                    });
            ecb.AddComponent(entity, new LoadSceneProcess { Scene = scene });
        }

        foreach (var (loadScene, entity) in SystemAPI.Query<RefRO<LoadSceneProcess>>().WithNone<SceneIsLoaded>().WithEntityAccess()) {
            if (!loadScene.ValueRO.Scene.isLoaded) {
                return;
            }

            ecb.AddComponent<SceneIsLoaded>(entity);
        }
        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}
