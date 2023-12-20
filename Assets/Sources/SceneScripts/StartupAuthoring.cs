using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine;
using Sources.Character;

namespace Sources.SceneScripts {

    public sealed class StartupAuthoring : MonoBehaviour {

        [SerializeField] private WeakObjectSceneReference _gameScene;
        [SerializeField] private GameObject _character;

        private void Awake() {
            EntityManager manager = World.DefaultGameObjectInjectionWorld.EntityManager;

            Entity scene = manager.CreateEntity();
            manager.AddComponentData(scene, new LoadSceneData {
                SceneReference = _gameScene
            });

            Entity inputs = manager.CreateEntity();
            manager.AddComponentData(inputs, new InputsData {
            });

            Entity character = manager.CreateEntity();
            manager.AddComponentObject(character, new CharacterData {
                Character = _character
            });

            manager.AddComponentData(character, new CharacterSpawnPoint {
                Position = new Vector3(0, 0, 4),
                Rotation = Quaternion.identity
            });
        }
    }
}