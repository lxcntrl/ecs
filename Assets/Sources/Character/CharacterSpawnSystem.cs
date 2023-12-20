using Sources.Character;
using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Character {
    public partial class CharacterSpawnSystem : SystemBase {

        private EntityQuery _playerSpawnQuery;
        private Unity.Mathematics.Random _random = new Unity.Mathematics.Random((uint)DateTime.Now.Millisecond);

        protected override void OnCreate() {
            using EntityQueryBuilder _playerSpawnBuilder = new EntityQueryBuilder(Allocator.Temp);

            _playerSpawnQuery = _playerSpawnBuilder.WithAll<CharacterSpawnPoint>().Build(this.EntityManager);
        }
        protected override void OnUpdate() {

            Entities.WithAll<CharacterSpawnPoint>().WithAll<CharacterData>().ForEach((Entity entity, CharacterData characterData) => {

                SpawnPlayer(entity, characterData);

            }).WithStructuralChanges().Run();

        }

        private void SpawnPlayer(Entity entity, CharacterData characterData) {
            
            var spawnPointArray = _playerSpawnQuery.ToComponentDataArray<CharacterSpawnPoint>(WorldUpdateAllocator);

            var spawnPointEntity = spawnPointArray[_random.NextInt(0, spawnPointArray.Length)];

             Object.Instantiate(characterData.Character, spawnPointEntity.Position, spawnPointEntity.Rotation);



            EntityManager.DestroyEntity(entity);
        }
    }
}
