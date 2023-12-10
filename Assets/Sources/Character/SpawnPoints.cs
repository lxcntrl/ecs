using Unity.Entities;
using Unity.Mathematics;

public struct CharacterSpawnPoint : IComponentData {
}

public struct SpawnPoint : IComponentData {
    public float3 Position;
    public quaternion Rotation;
}

public struct BotSpawnPoint : IComponentData {
}
