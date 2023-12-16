using System.Collections;
using System.Numerics;
using Unity.Entities;
using Unity.Mathematics;

public class SpawnPoint : IComponentData {
    public float3 Position;
    public quaternion Rotation;
}
