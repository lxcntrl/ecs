using System;
using System.Diagnostics;
using Unity.Entities;
using Unity.Entities.Content;
using UnityEngine;

public sealed class StartupAuthoring : MonoBehaviour {

    [SerializeField] private WeakObjectSceneReference _gameScene;
    [SerializeField] private GameObject _botPrefab;
    private void Awake() {
        
        var manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //var entity = manager.CreateEntity();
        //manager.AddComponentData(entity, new LoadSceneData { SceneReference = _gameScene });

        var bot = manager.CreateEntity();
        manager.AddComponentData(bot, new BotData {
            BotPrefab = _botPrefab
        });
        manager.AddComponentData(bot, new BotSpawnPoint {
        });

        manager.AddComponentData(bot, new RandomNumber {
            Value = 10
        });

    }
}
