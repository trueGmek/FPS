using UnityEngine;

namespace Weapons {
    public class Gun : MonoBehaviour {
        public int damage = 1;

        public float fireRate = 0.25f;
        public float weaponRange = 50f;
        public float hitForce = 100f;

        public Transform gunEnd;
    }
}