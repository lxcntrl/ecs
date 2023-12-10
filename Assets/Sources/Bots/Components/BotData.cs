using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct BotData : IComponentData
{
    public Entity BotPrefab;
    public float3 Position;
    public quaternion Rotation;
}
