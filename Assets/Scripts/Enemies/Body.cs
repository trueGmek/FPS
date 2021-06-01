using UnityEngine;
using Utils;
using Weapons;

namespace Enemies {
    public class Body : MonoBehaviour {
        public IntVariable initialHealth;

        private Shootable _shootable;
        private Rigidbody _rigidbody;

        private float _currentHealth;

        private void Awake() {
            _shootable = GetComponent<Shootable>();
            _rigidbody = GetComponent<Rigidbody>();

            _shootable.OnHit += ApplyDamage;
            _shootable.OnHit += ApplyForce;
        }

        private void Start() {
            _currentHealth = initialHealth.value;
        }

        private void ApplyDamage(HitData hitData) {
            _currentHealth -= hitData.GunDamage;
            if (_currentHealth <= 0) {
                gameObject.SetActive(false);
            }
        }

        private void ApplyForce(HitData hitData) {
            _rigidbody.AddForce(hitData.HitNormal * hitData.HitForce);
        }
    }
}