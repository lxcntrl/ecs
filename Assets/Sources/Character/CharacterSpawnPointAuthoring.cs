using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Sources.Character {
    public class CharacterSpawnPointAuthoring : MonoBehaviour {

        public class PlayerSpawnPointBaker : Baker<CharacterSpawnPointAuthoring> {
            public override void Bake(CharacterSpawnPointAuthoring authoring) {
                var transform = authoring.transform;

                var entity = GetEntity(TransformUsageFlags.None);

                AddComponent(entity, new CharacterSpawnPoint {
                    Position = transform.position,
                    Rotation = transform.rotation
                });
            }
        }
    }


    public struct CharacterSpawnPoint : IComponentData {
        public float3 Position;
        public quaternion Rotation;
    }

    public struct SpawnPoint : IComponentData {
    }

}