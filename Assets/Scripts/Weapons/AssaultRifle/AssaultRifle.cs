using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Weapons.AssaultRifle {
    public class AssaultRifle : RangedWeapon {
        public GameObject assaultRifleModel;
        public float fireRate;
        public FloatVariable range;
        public float hitForce;
        public float damage;
        public Ammunition ammunition;

        private RaycastAutomaticShoot _raycastShoot;
        private ParticleSystem _muzzleEffect;
        private AudioSource _gunAudio;
        private Coroutine _shootingCoroutine;

        public void OnValidate() {
            Assert.IsNotNull(ammunition, "Reference to ammunition not set in Assault Rifle");
        }

        public void Awake() {
            _raycastShoot = GetComponent<RaycastAutomaticShoot>();
            _gunAudio = GetComponent<AudioSource>();
        }

        public override void Initialize() {
            Instantiate(assaultRifleModel, transform);
            _muzzleEffect = GetComponentInChildren<ParticleSystem>();
        }


        public override Ammunition Ammunition => ammunition;

        public override void OnLeftButtonPressed() {
            _shootingCoroutine = StartCoroutine(ShootAction());
        }

        public override void OnLeftButtonReleased() {
            if (_shootingCoroutine != null) {
                StopCoroutine(_shootingCoroutine);
            }
        }

        private IEnumerator ShootAction() {
            while (true) {
                if (!ammunition.HasAmmunitionInMagazine()) {
                    break;
                }

                Shoot();
                yield return new WaitForSeconds(fireRate);
            }
        }

        private void Shoot() {
            _gunAudio.Play();
            _muzzleEffect.Play();
            _raycastShoot.ShootAction();
            ammunition.Shoot();
        }

        public override void OnReloadTriggered() {
            if (ammunition.CanReload()) {
                ammunition.Reload();
            }
        }

        public override void OnRightButtonPressed() {
            throw new NotImplementedException();
        }

        public override void OnRightButtonReleased() {
            throw new NotImplementedException();
        }
    }
}