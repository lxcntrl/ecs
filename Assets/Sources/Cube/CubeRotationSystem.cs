using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public partial class CubeRotationSystem : SystemBase {
    protected override void OnUpdate() {
        float dt = SystemAPI.Time.DeltaTime;
        
        foreach(var (entityData, transformData) 
                    in SystemAPI.Query<RefRO<CubeData>, RefRW<LocalTransform>>()) {
            transformData.ValueRW = transformData.ValueRO.RotateY(math.radians(entityData.ValueRO.speed * dt));
        }
        
        // foreach(var entityData in SystemAPI.Query<BotData>())
        // {
        //     Object.Instantiate(entityData.BotPrefab);
        // }
    }
}
