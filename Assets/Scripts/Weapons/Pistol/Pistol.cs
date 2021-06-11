using System;
using Items;
using UnityEngine;
using Utils;

namespace Weapons.Pistol {
    [RequireComponent(typeof(RaycastShoot))]
    public class Pistol : MonoBehaviour, IHoldable {
        public int damage = 1;

        public float fireRate = 0.25f;
        public FloatVariable weaponRange;
        public float hitForce = 100f;
        public Vector3 pistolPosition;
        public GameObject pistolGameObject;

        private RaycastShoot _raycastShoot;
        private ParticleSystem _muzzleEffect;
        private AudioSource _gunAudio;
        public Transform GunEnd { get; private set; }

        private void Awake() {
            _raycastShoot = GetComponent<RaycastShoot>();
            _gunAudio = GetComponent<AudioSource>();
        }

        public void Initialize() {
            var pistol = InitializeWithProperPositioning();
            GunEnd = pistol.GetComponentInChildren<GunEnd>().transform;
            _muzzleEffect = GetComponentInChildren<ParticleSystem>();
        }

        private GameObject InitializeWithProperPositioning() {
            var pistol = Instantiate(pistolGameObject, transform);
            pistol.transform.localPosition = pistolPosition;
            return pistol;
        }

        public void OnLeftButtonClick() {
            _raycastShoot.ShootAction();
            _muzzleEffect.Play();
            _gunAudio.Play();
        }

        public void OnRightButtonClick() {
            throw new NotImplementedException();
        }
    }
}