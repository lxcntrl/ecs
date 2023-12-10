using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine;
using System;

public partial class BotSpawnSystem : SystemBase {

    protected override void OnCreate() {
 
    }
    protected override void OnUpdate() {

        //var bot = Object.Instantiate(BotData)

        foreach (var (botData, spawnPointData, botTransform, entity) in SystemAPI.Query<BotData, RefRW<BotSpawnPoint>, RefRW<LocalTransform>>()
            .WithNone<IsBotHere>().WithEntityAccess()) {

            //foreach (var (botData, spawnPointData)  in SystemAPI.Query<BotData, RefRW<BotSpawnPoint>>()) {

            Unity.Mathematics.Random random = new Unity.Mathematics.Random();

            spawnPointData.ValueRW.Position = new Vector3(random.NextInt(0, 9), 0, random.NextInt(10, 15));

            //spawnPointData.ValueRW.Position = new Vector3(3, 2, 3);

            botData.BotPrefab = UnityEngine.Object.Instantiate(botData.BotPrefab, spawnPointData.ValueRO.Position, spawnPointData.ValueRO.Rotation);

            //EntityManager.AddComponent<IsBotHere>(entity);

        }

            
    }
}
