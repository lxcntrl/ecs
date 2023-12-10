using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class BulletSystem : SystemBase {

    protected override void OnUpdate() {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        foreach (var (bulletData, bulletTransform) in SystemAPI.Query<RefRO<BulletData>, RefRW<LocalTransform>>()) {

            bulletTransform.ValueRW.Position += bulletData.ValueRO.speed * bulletTransform.ValueRO.Right() * SystemAPI.Time.DeltaTime;
        }
    }
}
