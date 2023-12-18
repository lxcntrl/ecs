using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAuthoring : MonoBehaviour {
    public float speed = 5f;
    public float shootCooldown = 1;
    public GameObject BulletPrefab;
    public Vector3 Position;
    public Quaternion Rotation;
    public NavMeshAgent Agent;
    public Animator Animator;
    public GameObject Character;
    //public CharacterAnimator CharacterAnimator;

    private void Awake() {
        Character = Resources.Load<GameObject>("Prefabs/Player");
    }
}

//public class CharacterBaker : Baker<CharacterAuthoring> {
//    public override void Bake(CharacterAuthoring authoring) {
//        var entity = GetEntity(TransformUsageFlags.Dynamic);

//        AddComponent(entity, new CharacterData {
//            speed = authoring.speed,
//            shootCooldown = authoring.shootCooldown,
//            BulletPrefab = GetEntity(authoring.BulletPrefab, TransformUsageFlags.None)
//        });

//        //AddComponent(entity, new InputsData {
//        //});
//    }
//}