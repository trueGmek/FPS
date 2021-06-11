using System.Collections;
using UnityEngine;

namespace Weapons.Pistol {
    public class RaycastShoot : MonoBehaviour {
        private float _nextFireTime;

        private Camera _mainCamera;
        private Pistol _pistol;

        private void Start() {
            _pistol = GetComponent<Pistol>();
            _mainCamera = Camera.main;
        }

        public void ShootAction() {
            if (!(Time.time > _nextFireTime)) return;
            _nextFireTime = Time.time + _pistol.fireRate;

            Vector3 middleOfTheScreen = new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(middleOfTheScreen);

            if (Physics.Raycast(rayOrigin, _mainCamera.transform.forward, out var hit, _pistol.weaponRange.value)) {
                EvokeOnHitEvents(hit);
            }
        }

        private void EvokeOnHitEvents(RaycastHit hit) {
            Shootable shootableObject = hit.collider.GetComponent<Shootable>();
            if (shootableObject != null) {
                shootableObject.Hit(new HitData(_mainCamera.transform.forward, _pistol.hitForce, _pistol.damage));
            }
        }
    }
}