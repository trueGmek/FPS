using System;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Weapons.Pistol {
    [RequireComponent(typeof(RaycastShoot))]
    public class Pistol : RangedWeapon {
        public int damage = 1;
        public float fireRate = 0.25f;
        public float hitForce = 100f;
        public FloatVariable weaponRange;
        public Ammunition ammunition;
        public GameObject pistolGameObject;

        private float _nextFireTime;
        private RaycastShoot _raycastShoot;
        private ParticleSystem _muzzleEffect;
        private AudioSource _gunAudio;

        public override Ammunition Ammunition => ammunition;

        public void OnValidate() {
            Assert.IsNotNull(ammunition, "Reference to ammunition not set in Pistol");
        }

        private void Awake() {
            _raycastShoot = GetComponent<RaycastShoot>();
            _gunAudio = GetComponent<AudioSource>();
        }

        public override void Initialize() {
            Instantiate(pistolGameObject, transform);
            _muzzleEffect = GetComponentInChildren<ParticleSystem>();
        }

        public override void OnLeftButtonPressed() {
            if (!ammunition.HasAmmunitionInMagazine() || !(Time.time > _nextFireTime)) return;
            _nextFireTime = Time.time + fireRate;
            Shoot();
        }

        private void Shoot() {
            _raycastShoot.ShootAction();
            _muzzleEffect.Play();
            _gunAudio.Play();
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