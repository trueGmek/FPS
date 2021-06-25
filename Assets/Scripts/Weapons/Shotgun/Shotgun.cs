using System;
using System.Collections;
using Systems.Audio;
using UnityEngine;
using UnityEngine.Assertions;
using Grid = Systems.Grid;

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
        private bool _isReloadInProgress;

        private RaycastConeShoot _raycastConeShoot;
        private ParticleSystem _muzzleFlash;

        public void OnValidate() {
            Assert.IsNotNull(ammunition, "Reference to ammunition not set in Shotgun");
        }

        private void Awake() {
            _raycastConeShoot = GetComponent<RaycastConeShoot>();
        }

        public override void Initialize() {
            Instantiate(shotgunModel, transform);
            _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        }

        public override Ammunition Ammunition => ammunition;

        public override void OnLeftButtonPressed() {
            if (CanShoot()) {
                _nextFireTime = Time.time + fireRate;
                Shoot();
            }
        }

        private bool CanShoot() {
            return ammunition.HasAmmunitionInMagazine() && Time.time > _nextFireTime && !_isReloadInProgress;
        }

        private void Shoot() {
            _raycastConeShoot.ShootAction();
            _muzzleFlash.Play();
            ammunition.Shoot();
            Grid.AudioManager.Play(SoundNameProvider.ShotgunGunshot);
        }

        public override void OnReloadTriggered() {
            if (CanReload()) {
                StartCoroutine(ReloadAction());
            }
        }

        private bool CanReload() {
            return ammunition.CanReload() && !_isReloadInProgress;
        }

        private IEnumerator ReloadAction() {
            _isReloadInProgress = true;
            AudioSource reloadAudioSource = Grid.AudioManager.Play(SoundNameProvider.ShotgunReload);
            yield return new WaitWhile(() => reloadAudioSource.isPlaying);
            ammunition.Reload();
            _isReloadInProgress = false;
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