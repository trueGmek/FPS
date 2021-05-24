using System;
using UnityEngine;

namespace Weapons {
    public class Shootable : MonoBehaviour {
        public event Action<HitData> OnHit;

        public void Hit(HitData hitData) {
            OnHit?.Invoke(hitData);
        }
    }
}