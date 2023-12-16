using Unity.Entities;
using Unity.Mathematics;

public class CharacterSpawn : IComponentData {
    public CharacterAuthoring Character;
    public SpawnPoint Point;
}