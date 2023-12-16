using System;
using System.Diagnostics;
using Unity.Entities;
using Unity.Entities.Content;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public sealed class StartupAuthoring : MonoBehaviour {

    [SerializeField] private WeakObjectSceneReference _gameScene;
    [SerializeField] private GameObject _character;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private GameObject _botPrefab;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speed;
    private float _shootCooldown;

    private void Awake() {
        _position = new Vector3(1, 1, 1);
        _rotation = new Quaternion();
        _rotation = Quaternion.Euler(1, 1, 1); 

        var manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var scene = manager.CreateEntity();
        manager.AddComponentData(scene, new LoadSceneData {
            SceneReference = _gameScene
        });

        var character = manager.CreateEntity();
        manager.AddComponentData(character, new CharacterData {
            Character = _character,
            Speed = _speed,
            ShootCooldown = _shootCooldown,
            BulletPrefab = _bulletPrefab
        });
        manager.AddComponentData(character, new SpawnPoint {
            Position = _position,
            Rotation = _rotation
        });

       

        manager.AddComponentData(character, new LocalTransform {
        });

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
