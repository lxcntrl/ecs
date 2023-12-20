using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Character {

    public class CharacterAuthoring : MonoBehaviour {

        [SerializeField] private GameObject _character;

        public GameObject Character => _character;
    }
}
