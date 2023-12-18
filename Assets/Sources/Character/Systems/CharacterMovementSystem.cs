using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

/*
public partial struct CharacterMovementSystem : ISystem {
    public void OnUpdate(ref SystemState state) {

        float dt = SystemAPI.Time.DeltaTime;
        foreach (var (data, inputs, transform) in SystemAPI.Query<RefRO<CharacterData>, RefRO<InputsData>, RefRW<LocalTransform>>()) {
            float3 position = transform.ValueRO.Position;

            position.x += inputs.ValueRO.move.x * data.ValueRO.Speed * dt;
            position.z += inputs.ValueRO.move.y * data.ValueRO.Speed * dt;
            transform.ValueRW.Position = position;
        };
    }
}
*/

public partial class CharacterMovementSystem : SystemBase {

    private Entity characterEntity;
    private Entity inputEntity;
    private EntityManager entityManager;
    private CharacterData characterData;
    private InputsData inputData;

    protected override void OnCreate() {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

    }

    protected override void OnUpdate() {

        //inputEntity = SystemAPI.GetSingletonEntity<InputsData>();
        //inputData = entityManager.GetComponentData<InputsData>(inputEntity);

            foreach (var (characterData, characterTransform, spawnPoint, inputData, entity)
            in SystemAPI.Query<CharacterData, RefRW<LocalTransform>, SpawnPoint, RefRW<InputsData>>().WithEntityAccess()) {

            float3 position = characterTransform.ValueRO.Position;

            float moveX = inputData.ValueRO.move.x * characterData.Speed * SystemAPI.Time.DeltaTime;
            float moveZ = inputData.ValueRO.move.y * characterData.Speed * SystemAPI.Time.DeltaTime;

            float3 newPosition = characterTransform.ValueRW.Position + new float3(moveX, 0f, moveZ);
            characterTransform.ValueRW.Position = newPosition;
            //characterTransform.ValueRW.Translate(new float3(moveX, 0f, moveZ));
        };
    }
    private void Move(Entity characterEntity, ref CharacterData characterData, ref LocalTransform characterTransform) {
        

        float moveX = inputData.move.x * characterData.Speed * SystemAPI.Time.DeltaTime;
        float moveZ= inputData.move.y * characterData.Speed * SystemAPI.Time.DeltaTime;



        //characterTransform.Position = direction;
        float3 MoveDir = new float3(moveX, 0, moveZ);

        characterTransform.Position += MoveDir;

        //characterTransform.Rotation.value += math.radians(characterTransform.Rotation.value * SystemAPI.Time.DeltaTime);

        //if (/*math.all(characterTransform.Position != float3.zero)*/) {
            Quaternion toRotation = Quaternion.LookRotation(MoveDir, Vector3.up);
            characterTransform.Rotate(Quaternion.RotateTowards(characterTransform.Rotation, toRotation, 10f));
        //}
        //Vector3 newDir = Vector3.RotateTowards(characterTransform, new Vector3 )


        //Vector3 dir = (Vector2)inputData.mousePos - (Vector2)Camera.main.WorldToScreenPoint(characterTransform.Position);
        //float angle = math.degrees(math.atan2(dir.z, dir.x));
        //characterTransform.Rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        entityManager.SetComponentData(characterEntity, characterTransform);
    }


    private float nextShootTime;
    private void Shoot() {
        if (inputData.PressingLMB /*&& nextShootTime < SystemAPI.Time.ElapsedTime*/) {
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

            Entity bulletEntity = entityManager.CreateEntity();

            Entities.WithAll<CharacterData>().ForEach((Entity bulletEntity, CharacterData characterData) => {
                Object.Instantiate(characterData.BulletPrefab);
            }).WithoutBurst().Run();

            ecb.AddComponent(bulletEntity, new BulletData { Speed = 10f });

            LocalTransform bulletTransform = entityManager.GetComponentData<LocalTransform>(bulletEntity);
            bulletTransform.Rotation = entityManager.GetComponentData<LocalTransform>(bulletEntity).Rotation;
            LocalTransform characterTransform = entityManager.GetComponentData<LocalTransform>(characterEntity);
            bulletTransform.Position = characterTransform.Position;
            bulletTransform.Rotation = characterTransform.Rotation;

            ecb.SetComponent(bulletEntity, bulletTransform);
            ecb.Playback(entityManager);

            //EntityManager.AddComponentData(bulletEntity, new LocalTransform { });

            nextShootTime = /*(float)SystemAPI.Time.ElapsedTime +*/ characterData.ShootCooldown;
        }

    }
    }