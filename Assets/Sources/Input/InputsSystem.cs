using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class InputsSystem : SystemBase {

    private Controls inputs;

    protected override void OnCreate() {

        inputs = new Controls();
        inputs.Enable();
    }
    protected override void OnUpdate() {
        Vector2 moveVector = inputs.Character.Move.ReadValue<Vector2>();
        Vector2 mousePos = inputs.Character.MousePosition.ReadValue<Vector2>();
        bool isPressingLMB = inputs.Character.Shoot.ReadValue<float>() == 1 ? true : false; //Если выбрать Shoot value, а не Button
        //bool isPressingLMB = inputs.Character.Shoot.ReadValue<bool>();

        SystemAPI.SetSingleton(new InputsData {
            move = moveVector,
            mousePos = mousePos,
            PressingLMB = isPressingLMB
        });
    }
}
