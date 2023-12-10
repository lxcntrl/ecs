using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public partial class BotSpawnSystem : SystemBase {

    //private GameObject _bot;

    protected override void OnCreate() {

        //var manager = World.DefaultGameObjectInjectionWorld.EntityManager;


    }
    protected override void OnUpdate() {

        //foreach (var (botData, transformData) in SystemAPI.Query<BotData, RefRW<LocalTransform>>()) {

        //    EntityManager.Instantiate(botData.BotPrefab);
        //    transformData.ValueRW.Position += 1; 
        //}

    }

}
