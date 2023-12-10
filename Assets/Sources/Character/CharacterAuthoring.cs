using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CharacterAuthoring : MonoBehaviour {
    public float speed = 5f;
    public float shootCooldown = 1;
    public GameObject BulletPrefab;
    public Vector3 Position;
    public Quaternion Rotation;
}

public class CharacterBaker : Baker<CharacterAuthoring> {
    public override void Bake(CharacterAuthoring authoring) {
        var entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new CharacterData {
            speed = authoring.speed,
            shootCooldown = authoring.shootCooldown,
            BulletPrefab = GetEntity(authoring.BulletPrefab, TransformUsageFlags.None)
        });

        //AddComponent(entity, new InputsData {
        //});

        AddComponent(entity, new SpawnPoint {
            Position = authoring.Position,
            Rotation = authoring.Rotation
        });
    }
}