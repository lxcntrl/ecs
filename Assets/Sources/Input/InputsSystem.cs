using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class InputsSystem : SystemBase {

    private Controls inputs;

    protected override void OnCreate() {
        //if (!SystemAPI.TryGetSingleton<InputsData>(out InputsData data)) {
        //    EntityManager.CreateEntity(typeof(InputsData));
        //}

        //var manager = World.DefaultGameObjectInjectionWor ld.EntityManager;


        inputs = new Controls();
        inputs.Enable();
    }
    protected override void OnUpdate() {
        //Vector2 moveVector = inputs.Character.Move.ReadValue<Vector2>();
        //Vector2 mousePos = inputs.Character.MousePosition.ReadValue<Vector2>();
        //bool isPressingLMB = inputs.Character.Shoot.ReadValue<float>() == 1 ? true : false; //Если выбрать Shoot value, а не Button
        ////bool isPressingLMB = inputs.Character.Shoot.ReadValue<bool>();

        //SystemAPI.SetSingleton(new InputsData {
        //    move = moveVector,
        //    mousePos = mousePos,
        //    PressingLMB = isPressingLMB
        //});


        foreach (var inputData in SystemAPI.Query<RefRW<InputsData>>()) {
            inputData.ValueRW.move = inputs.Character.Move.ReadValue<Vector2>();
        }
        //    if (inputs.Character.Shoot.IsPressed()) {
        //        foreach (var (characterData, transformData) in SystemAPI.Query<RefRO<CharacterData>, RefRW<LocalTransform>>()) {


        //            EntityManager.Instantiate(characterData.ValueRO.BulletPrefab);

        //            transformData.ValueRW.Position = transformData.ValueRO.Position + 1f * SystemAPI.Time.DeltaTime;

        //            //Object.Instantiate<entity>(characterData.ValueRO.BulletPrefab, transformData.ValueRO.Position, transformData.ValueRO.Rotation);
        //    }
        //}
    }
}
