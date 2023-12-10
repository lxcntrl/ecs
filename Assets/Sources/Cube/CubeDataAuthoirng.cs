using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CubeDataAuthoring : MonoBehaviour {

    private float speed = 20f;

    public class CubeBaker : Baker<CubeDataAuthoring> {

        public override void Bake(CubeDataAuthoring authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new CubeData { 
                speed = authoring.speed 
            });
        }
    }
}


