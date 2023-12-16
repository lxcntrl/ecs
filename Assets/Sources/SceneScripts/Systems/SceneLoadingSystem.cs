using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.Transforms;

public partial class SceneLoadingSystem : SystemBase {

    //private EntityManager manager;

    protected override void OnCreate() {
        //manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

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

            Entities.WithAll<CharacterData>().WithAll<SpawnPoint>().WithAll<LocalTransform>()
                .ForEach((Entity entity, CharacterData characterData, SpawnPoint spawnPoint, LocalTransform localTransform) =>
                {
                    Object.Instantiate(characterData.Character, spawnPoint.Position, spawnPoint.Rotation);
                    localTransform.Position += localTransform.Forward() * 3;
            }).WithoutBurst().Run();

            //ecb.AddComponent(entity, new SceneIsLoaded());
            ecb.AddComponent<SceneIsLoaded>(entity);
            //ecb.DestroyEntity(entity);

        }

       



        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}
