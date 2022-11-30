using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Kawaiisun.SimpleHostile
{
    [CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
    public class AlexGun : ScriptableObject
    {
        public new string name;
        public float fireRate;
        public GameObject prefab;
    }
}