using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;
using System;
using UnityEngine;

public partial class CharacterSystem : SystemBase {

    private EntityQuery _playerSpawnPointQuery;
    private Unity.Mathematics.Random _random;

    protected override void OnCreate() {

        //using var spawnPointBuilder = new EntityQueryBuilder(Allocator.Temp);

        //_playerSpawnPointQuery = spawnPointBuilder.WithAll<CharacterData>().WithAll<SpawnPoint>().Build(this);

        //_random = new Unity.Mathematics.Random((uint)DateTime.Now.Millisecond);

        //var spawnPointArray = _playerSpawnPointQuery.ToComponentDataArray<SpawnPoint>(WorldUpdateAllocator);

        //var spawnPointEntity = spawnPointArray[_random.NextInt(0, spawnPointArray.Length)];
    }
    protected override void OnUpdate() {

    }
}
