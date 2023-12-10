using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BotData : IComponentData
{
    public GameObject BotPrefab;
}

public struct BotSpawnPoint : IComponentData {
    public float3 Position;
    public quaternion Rotation;
}

public struct IsBotHere : IComponentData {
}

public struct RandomNumber : IComponentData {
    public uint Value;
}