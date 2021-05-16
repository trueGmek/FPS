using System;
using UnityEngine;

namespace Weapons {
    public class Shootable : MonoBehaviour {
        public int currentHealth = 3;

        private Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }


        public void ApplyDamage(int damageAmount) {
            currentHealth -= damageAmount;
            if (currentHealth <= 0) {
                gameObject.SetActive(false);
            }
        }
    }
}