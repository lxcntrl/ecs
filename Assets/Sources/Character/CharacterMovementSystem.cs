using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEditor.Build.Player;
using UnityEngine;

/*
public partial struct CharacterMovementSystem : ISystem {
    public void OnUpdate(ref SystemState state) {

        float dt = SystemAPI.Time.DeltaTime;
        foreach (var (data, inputs, transform) in SystemAPI.Query<RefRO<CharacterData>, RefRO<InputsData>, RefRW<LocalTransform>>()) {
            float3 position = transform.ValueRO.Position;

            position.x += inputs.ValueRO.move.x * data.ValueRO.speed * dt;
            position.z += inputs.ValueRO.move.y * data.ValueRO.speed * dt;
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
        
        characterEntity = SystemAPI.GetSingletonEntity<CharacterData>();
        inputEntity = SystemAPI.GetSingletonEntity<InputsData>();

        characterData = entityManager.GetComponentData<CharacterData>(characterEntity);
        inputData = entityManager.GetComponentData<InputsData>(inputEntity);

        Move();
        Shoot();

            //foreach (var (data, inputs, transform) in SystemAPI.Query<RefRO<CharacterData>, RefRO<InputsData>, RefRW<LocalTransform>>()) {
            //    float3 position = transform.ValueRO.Position;

        //    position.x += inputs.ValueRO.move.x * data.ValueRO.speed * dt;
        //    position.z += inputs.ValueRO.move.y * data.ValueRO.speed * dt;
        //    transform.ValueRW.Position = position;
        //};
        }
    private void Move() {


        var characterTransform = entityManager.GetComponentData<LocalTransform>(characterEntity);

        characterTransform.Position += new float3(inputData.move * characterData.speed * SystemAPI.Time.DeltaTime, 0);

        Vector2 dir = (Vector2)inputData.mousePos - (Vector2)Camera.main.WorldToScreenPoint(characterTransform.Position);
        float angle = math.degrees(math.atan2(dir.y, dir.x));
        characterTransform.Rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        entityManager.SetComponentData(characterEntity, characterTransform);
    }


    private float nextShootTime;
    private void Shoot() {
        if (inputData.PressingLMB && nextShootTime < SystemAPI.Time.ElapsedTime) {
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

            Entity bulletEntity = entityManager.Instantiate(characterData.BulletPrefab);

            LocalTransform bulletTransform = entityManager.GetComponentData<LocalTransform>(bulletEntity);
            bulletTransform.Rotation = entityManager.GetComponentData<LocalTransform>(bulletEntity).Rotation;
            LocalTransform characterTransform = entityManager.GetComponentData<LocalTransform>(characterEntity);
            bulletTransform.Position = characterTransform.Position + characterTransform.Right() + characterTransform.Up();

            ecb.Playback(entityManager);

            nextShootTime = (float)SystemAPI.Time.ElapsedTime + characterData.shootCooldown;


        }

    }
    }