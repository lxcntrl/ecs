using Unity.Entities;
using Unity.Mathematics;

public struct InputsData : IComponentData {
    public float2 move;
    public float2 mousePos;
    public bool PressingLMB;
}
