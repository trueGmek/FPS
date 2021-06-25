using System;
using Items;
using UnityEngine;
using UnityEngine.Assertions;

namespace Weapons.Shotgun {
    [RequireComponent(typeof(RaycastConeShoot))]
    public class Shotgun : RangedWeapon {
        public int damage = 2;
        public int numberOfProjectiles = 5;
        public float fireRate = 0.122f;
        public float range = 10f;
        public float hitForce = 200f;
        public float shotSpreadRadius = 2;

        public GameObject shotgunModel;
        public Ammunition ammunition;


        private float _nextFireTime;
        private RaycastConeShoot _raycastConeShoot;
        private ParticleSystem _muzzleFlash;
        private AudioSource _gunshot;

        public void OnValidate() {
            Assert.IsNotNull(ammunition, "Reference to ammunition not set in Shotgun");
        }

        private void Awake() {
            _raycastConeShoot = GetComponent<RaycastConeShoot>();
            _gunshot = GetComponent<AudioSource>();
        }

        public override void Initialize() {
            Instantiate(shotgunModel, transform);
            _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        }

        public override Ammunition Ammunition => ammunition;

        public override void OnLeftButtonPressed() {
            if (!ammunition.HasAmmunitionInMagazine() || !(Time.time > _nextFireTime)) return;
            _nextFireTime = Time.time + fireRate;
            Shoot();
        }

        private void Shoot() {
            _raycastConeShoot.ShootAction();
            _muzzleFlash.Play();
            _gunshot.Play();
            ammunition.Shoot();
        }

        public override void OnReloadTriggered() {
            if (ammunition.CanReload()) {
                ammunition.Reload();
            }
        }

        public override void OnLeftButtonReleased() {
        }

        public override void OnRightButtonPressed() {
            throw new NotImplementedException();
        }

        public override void OnRightButtonReleased() {
            throw new NotImplementedException();
        }
    }
}