using System;
using System.Collections;
using Systems.Audio;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Grid = Systems.Grid;

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
        private Coroutine _shootingCoroutine;
        private bool _isReloadInProgress;

        public void OnValidate() {
            Assert.IsNotNull(ammunition, "Reference to ammunition not set in Assault Rifle");
        }

        public void Awake() {
            _raycastShoot = GetComponent<RaycastAutomaticShoot>();
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
                if (CanShoot()) {
                    Shoot();
                }

                yield return new WaitForSeconds(fireRate);
            }
        }

        private bool CanShoot() {
            return ammunition.HasAmmunitionInMagazine() && !_isReloadInProgress;
        }

        private void Shoot() {
            Grid.AudioManager.Play(SoundNameProvider.AssaultRifleGunshot);
            _muzzleEffect.Play();
            _raycastShoot.ShootAction();
            ammunition.Shoot();
        }

        public override void OnReloadTriggered() {
            if (CanReload()) {
                StartCoroutine(ReloadAction());
            }
        }

        private bool CanReload() {
            return Ammunition.CanReload() && !_isReloadInProgress;
        }

        private IEnumerator ReloadAction() {
            _isReloadInProgress = true;
            AudioSource reloadAudioSource =
                Grid.AudioManager.Play(SoundNameProvider.AssaultRifleReload);
            yield return new WaitWhile(() => reloadAudioSource.isPlaying);
            ammunition.Reload();
            _isReloadInProgress = false;
        }

        public override void OnRightButtonPressed() {
            throw new NotImplementedException();
        }

        public override void OnRightButtonReleased() {
            throw new NotImplementedException();
        }
    }
}