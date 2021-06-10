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

        private RaycastConeShoot _raycastConeShoot;
        private ParticleSystem _muzzleFlash;

        private void Awake() {
            _raycastConeShoot = GetComponent<RaycastConeShoot>();
        }

        public void Initialize() {
            Instantiate(shotgunModel, transform);
            _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        }

        public void OnLeftButtonClick() {
            _raycastConeShoot.ShootAction();
            _muzzleFlash.Play();
        }


        public void OnRightButtonClick() {
            throw new NotImplementedException();
        }
    }
}