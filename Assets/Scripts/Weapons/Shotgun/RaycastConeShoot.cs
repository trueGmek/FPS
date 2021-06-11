using UnityEngine;

namespace Weapons.Shotgun {
    public class RaycastConeShoot : MonoBehaviour {
        private Camera _camera;
        private Shotgun _shotgun;

        private void Awake() {
            _camera = Camera.main;
            _shotgun = GetComponent<Shotgun>();
        }


        public void ShootAction() {
            Vector3 centerOfCircleInsideCone =
                _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _shotgun.range));
            var rayOrigin = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.1f));

            for (int i = 0; i < _shotgun.numberOfProjectiles; i++) {
                ShootProjectile(centerOfCircleInsideCone, rayOrigin);
            }
        }

        private void ShootProjectile(Vector3 centerOfCircleInsideCone, Vector3 rayOrigin) {
            var positionOnUnitCircle = Random.insideUnitCircle * _shotgun.shotSpreadRadius;
            var pointPosition = centerOfCircleInsideCone +
                                Quaternion.Euler(_camera.transform.rotation.eulerAngles) *
                                new Vector3(positionOnUnitCircle.x, positionOnUnitCircle.y, 0f);
            var rayDirection = (pointPosition - rayOrigin).normalized;

            if (Physics.Raycast(rayOrigin, rayDirection, out var hit, _shotgun.range)) {
                EvokeOnHitEvents(hit);
            }
        }


        private void EvokeOnHitEvents(RaycastHit raycastHit) {
            Shootable shootableObject = raycastHit.collider.GetComponent<Shootable>();
            if (shootableObject != null) {
                shootableObject.Hit(new HitData(_camera.transform.forward, _shotgun.hitForce, _shotgun.damage));
            }
        }
    }
}