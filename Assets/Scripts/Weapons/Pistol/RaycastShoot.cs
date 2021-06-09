using System.Collections;
using UnityEngine;

namespace Weapons.Pistol {
    public class RaycastShoot : MonoBehaviour {
        public float shootDuration;

        private float _nextFireTime;

        private Camera _mainCamera;
        private WaitForSeconds _shootDuration;
        private AudioSource _gunAudio;
        private LineRenderer _laserLine;
        private Pistol _pistol;

        private void Start() {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
            _pistol = GetComponent<Pistol>();


            _mainCamera = Camera.main;
            _shootDuration = new WaitForSeconds(shootDuration);
        }

        public void ShootAction() {
            if (Time.time > _nextFireTime) {
                _nextFireTime = Time.time + _pistol.fireRate;

                StartCoroutine(ShotEffects());

                Vector3 middleOfTheScreen = new Vector3(0.5f, 0.5f, 0.5f);
                Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(middleOfTheScreen);

                if (Physics.Raycast(rayOrigin, _mainCamera.transform.forward, out var hit, _pistol.weaponRange.value)) {
                    EvokeOnHitEvents(hit);
                    SetLaserPositionOnHit(hit);
                    return;
                }

                SetLaserPositionsOnMiss();
            }
        }

        private void EvokeOnHitEvents(RaycastHit hit) {
            Shootable shootableObject = hit.collider.GetComponent<Shootable>();
            if (shootableObject != null) {
                shootableObject.Hit(new HitData(_mainCamera.transform.forward, _pistol.hitForce, _pistol.damage));
            }
        }

        private void SetLaserPositionsOnMiss() {
            _laserLine.SetPosition(0, _pistol.GunEnd.position);
            _laserLine.SetPosition(1, _mainCamera.transform.forward * _pistol.weaponRange.value);
        }

        private void SetLaserPositionOnHit(RaycastHit hit) {
            _laserLine.SetPosition(0, _pistol.GunEnd.position);
            _laserLine.SetPosition(1, hit.point);
        }

        private IEnumerator ShotEffects() {
            _gunAudio.Play();
            _laserLine.enabled = true;

            yield return _shootDuration;

            _laserLine.enabled = false;
        }
    }
}