using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.Transforms;
using UnityEngine.TextCore.Text;

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


            Entities.WithAll<CharacterData>().WithAll<SpawnPoint>().WithAll<LocalTransform>().WithAll<InputsData>()
                .ForEach((Entity entity, CharacterData characterData, SpawnPoint spawnPoint, LocalTransform localTransform) => {
                    
                    if (characterData.Character != null) {
                       
                        var player = Object.Instantiate(characterData.Character, spawnPoint.Position, spawnPoint.Rotation);
                        characterData.Character = player;
                    }
                }).WithoutBurst().WithStructuralChanges().Run();
            ecb.AddComponent<SceneIsLoaded>(entity);
        }
        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}
