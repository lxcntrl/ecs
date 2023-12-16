using Unity.Entities;
using UnityEngine;

public class CharacterData : IComponentData {
    public float Speed;
    public float ShootCooldown;
    public GameObject BulletPrefab;
    public GameObject Character;
}

