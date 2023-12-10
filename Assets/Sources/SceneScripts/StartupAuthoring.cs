using System;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine;

public sealed class StartupAuthoring : MonoBehaviour {

    [SerializeField] private WeakObjectSceneReference _gameScene;
    //[SerializeField] private GameObject _botPrefab;

    private Vector3 _position;
    private Quaternion _rotation;

    private void Awake() {
        //var manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //var entity = manager.CreateEntity();
        //manager.AddComponentData(entity, new LoadSceneData { SceneReference = _gameScene });

        //var bot = manager.CreateEntity();

        //manager.AddComponentData(bot, new BotData {
        //    BotPrefab = GetEntity(_botPrefab),
        //    Position = _position,
        //    Rotation = _rotation
        //});



    }
}
