using Unity.Entities;

public struct CharacterData : IComponentData {
    public float speed;
    public float shootCooldown;
    public Entity BulletPrefab;
}

