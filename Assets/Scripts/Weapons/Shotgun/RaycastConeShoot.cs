using System.Collections;
using UnityEngine;

namespace Weapons.Shotgun {
    public class RaycastConeShoot : MonoBehaviour {
        public float shootDuration;

        private float _nextFireTime;
        private WaitForSeconds _shootDuration;

        private Camera _camera;
        private GunEnd _gunEnd;
        private Shotgun _shotgun;
        private AudioSource _shotgunAudio;

        private void Awake() {
            _camera = Camera.main;
            _shotgun = GetComponent<Shotgun>();
            _shotgunAudio = GetComponent<AudioSource>();
        }

        private void Start() {
            _shootDuration = new WaitForSeconds(shootDuration);

            _gunEnd = GetComponentInChildren<GunEnd>();
        }

        public void ShootAction() {
            if (!(Time.time > _nextFireTime)) return;
            _nextFireTime = Time.time + _shotgun.fireRate;

            StartCoroutine(ShootEffects());

            Vector3 centerOfCircleInsideCone =
                _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _shotgun.range));
            var rayOrigin = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.1f));

            for (int i = 0; i < _shotgun.numberOfProjectiles; i++) {
                ShootProjectile(centerOfCircleInsideCone, rayOrigin);
            }
        }

        private IEnumerator ShootEffects() {
            _shotgunAudio.Play();
            yield return _shootDuration;
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