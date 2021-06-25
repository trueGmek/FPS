using System;
using System.Collections;
using Systems.Audio;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Grid = Systems.Grid;

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
        private bool _isReloadInProgress;

        private RaycastShoot _raycastShoot;
        private ParticleSystem _muzzleEffect;

        public override Ammunition Ammunition => ammunition;

        public void OnValidate() {
            Assert.IsNotNull(ammunition, "Reference to ammunition not set in Pistol");
        }

        private void Awake() {
            _raycastShoot = GetComponent<RaycastShoot>();
        }

        public override void Initialize() {
            Instantiate(pistolGameObject, transform);
            _muzzleEffect = GetComponentInChildren<ParticleSystem>();
        }

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
            _raycastShoot.ShootAction();
            _muzzleEffect.Play();
            Grid.AudioManager.Play(SoundNameProvider.PistolGunshot);
            ammunition.Shoot();
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
            AudioSource reloadAudioSource = Grid.AudioManager.Play(SoundNameProvider.PistolReload);
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