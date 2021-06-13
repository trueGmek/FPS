using System;
using System.Collections;
using Items;
using UnityEngine;
using Utils;

namespace Weapons.AssaultRifle {
    public class AssaultRifle : MonoBehaviour, IHoldable {
        public GameObject assaultRifleModel;
        public float fireRate;
        public FloatVariable range;
        public float hitForce;
        public float damage;

        private RaycastAutomaticShoot _raycastShoot;
        private ParticleSystem _muzzleEffect;
        private AudioSource _gunAudio;
        private Coroutine _shootingCoroutine;

        public void Awake() {
            _raycastShoot = GetComponent<RaycastAutomaticShoot>();
            _gunAudio = GetComponent<AudioSource>();
        }

        public void Initialize() {
            Instantiate(assaultRifleModel, transform);
            _muzzleEffect = GetComponentInChildren<ParticleSystem>();
        }

        public void OnLeftButtonPressed() {
            _shootingCoroutine = StartCoroutine(Shoot());
        }

        public void OnLeftButtonReleased() {
            StopCoroutine(_shootingCoroutine);
        }

        private IEnumerator Shoot() {
            while (true) {
                _gunAudio.Play();
                _muzzleEffect.Play();
                _raycastShoot.ShootAction();
                yield return new WaitForSeconds(fireRate);
            }
        }

        public void OnRightButtonPressed() {
            throw new NotImplementedException();
        }

        public void OnRightButtonReleased() {
            throw new NotImplementedException();
        }
    }
}