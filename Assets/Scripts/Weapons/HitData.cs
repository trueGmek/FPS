using UnityEngine;

namespace Weapons {
    public readonly struct HitData {
        public readonly Vector3 HitNormal;
        public readonly float HitForce;
        public readonly float GunDamage;

        public HitData(Vector3 hitNormal, float hitForce, float gunDamage) {
            HitNormal = hitNormal;
            HitForce = hitForce;
            GunDamage = gunDamage;
        }
    }
}