using UnityEngine;

namespace Weapons.AssaultRifle {
    [RequireComponent(typeof(AssaultRifle))]
    public class RaycastAutomaticShoot : MonoBehaviour {
        private Camera _mainCamera;
        private AssaultRifle _assaultRifle;

        private void Start() {
            _assaultRifle = GetComponent<AssaultRifle>();
            _mainCamera = Camera.main;
        }

        public void ShootAction() {
            Vector3 middleOfTheScreen = new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(middleOfTheScreen);

            if (Physics.Raycast(rayOrigin, _mainCamera.transform.forward, out var hit,
                _assaultRifle.range.value)) {
                EvokeOnHitEvents(hit);
            }
        }

        private void EvokeOnHitEvents(RaycastHit hit) {
            Shootable shootableObject = hit.collider.GetComponent<Shootable>();
            if (shootableObject != null) {
                shootableObject.Hit(new HitData(_mainCamera.transform.forward, _assaultRifle.hitForce,
                    _assaultRifle.damage));
            }
        }
    }
}