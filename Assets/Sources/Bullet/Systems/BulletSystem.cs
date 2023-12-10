using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class BulletSystem : SystemBase {

    protected override void OnUpdate() {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        foreach (var (bulletData, bulletTransform, entity) in SystemAPI.Query<RefRO<BulletData>, RefRW<LocalTransform>>().WithEntityAccess()) {

            bulletTransform.ValueRW.Position += bulletData.ValueRO.speed * bulletTransform.ValueRO.Forward() * SystemAPI.Time.DeltaTime;
            entityManager.SetComponentData<LocalTransform>(entity, bulletTransform.ValueRO);
        }
    }
}
