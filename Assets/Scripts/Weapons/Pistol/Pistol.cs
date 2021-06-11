using System;
using Items;
using UnityEngine;
using Utils;

namespace Weapons.Pistol {
    [RequireComponent(typeof(RaycastShoot))]
    public class Pistol : MonoBehaviour, IHoldable {
        public int damage = 1;
        public float fireRate = 0.25f;
        public float hitForce = 100f;
        public FloatVariable weaponRange;
        public GameObject pistolGameObject;

        private float _nextFireTime;
        private RaycastShoot _raycastShoot;
        private ParticleSystem _muzzleEffect;
        private AudioSource _gunAudio;

        private void Awake() {
            _raycastShoot = GetComponent<RaycastShoot>();
            _gunAudio = GetComponent<AudioSource>();
        }

        public void Initialize() {
            Instantiate(pistolGameObject, transform);
            _muzzleEffect = GetComponentInChildren<ParticleSystem>();
        }

        public void OnLeftButtonClick() {
            if (!(Time.time > _nextFireTime)) return;
            _nextFireTime = Time.time + fireRate;

            _raycastShoot.ShootAction();
            _muzzleEffect.Play();
            _gunAudio.Play();
        }

        public void OnRightButtonClick() {
            throw new NotImplementedException();
        }
    }
}