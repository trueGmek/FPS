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

        public Transform GunEnd { get; private set; }

        private void Awake() {
            _raycastShoot = GetComponent<RaycastShoot>();
        }

        public void Initialize() {
            var pistol = InitializeWithProperPositioning();
            GunEnd = pistol.GetComponentInChildren<GunEnd>().transform;
        }

        private GameObject InitializeWithProperPositioning() {
            var pistol = Instantiate(pistolGameObject, transform);
            pistol.transform.localPosition = pistolPosition;
            return pistol;
        }

        public void OnLeftButtonClick() {
            _raycastShoot.ShootAction();
        }

        public void OnRightButtonClick() {
            throw new NotImplementedException();
        }
    }
}