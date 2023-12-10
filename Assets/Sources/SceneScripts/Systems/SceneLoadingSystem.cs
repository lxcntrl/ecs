using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine.SceneManagement;
using UnityEngine;

public partial class SceneLoadingSystem : SystemBase {

    protected override void OnUpdate() {
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        foreach (var (loadScene, entity) in SystemAPI.Query<RefRO<LoadSceneData>>().WithNone<LoadSceneProcess>().WithEntityAccess()) {

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
            //ecb.AddComponent(entity, new SceneIsLoaded());
            ecb.AddComponent<SceneIsLoaded>(entity);
            //ecb.DestroyEntity(entity);
        }

       



        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}
