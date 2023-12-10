using Unity.Entities;
using Unity.Mathematics;

public struct CharacterSpawnPoint : IComponentData {
    public float3 Position;
    public quaternion Rotation;
}