using System;
using Items;
using UnityEngine;

namespace Weapons.Shotgun {
    [RequireComponent(typeof(RaycastConeShoot))]
    public class Shotgun : MonoBehaviour, IHoldable {
        public int damage = 2;
        public int numberOfProjectiles = 5;
        public float fireRate = 0.122f;
        public float range = 10f;
        public float hitForce = 200f;
        public float shotSpreadRadius = 2;
        public GameObject shotgunModel;

        private float _nextFireTime;
        private RaycastConeShoot _raycastConeShoot;
        private ParticleSystem _muzzleFlash;
        private AudioSource _gunshot;

        private void Awake() {
            _raycastConeShoot = GetComponent<RaycastConeShoot>();
            _gunshot = GetComponent<AudioSource>();
        }

        public void Initialize() {
            Instantiate(shotgunModel, transform);
            _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        }

        public void OnLeftButtonPressed() {
            if (!(Time.time > _nextFireTime)) return;
            _nextFireTime = Time.time + fireRate;

            _raycastConeShoot.ShootAction();
            _muzzleFlash.Play();
            _gunshot.Play();
        }

        public void OnLeftButtonReleased() {
        }

        public void OnRightButtonPressed() {
            throw new NotImplementedException();
        }

        public void OnRightButtonReleased() {
            throw new NotImplementedException();
        }
    }
}