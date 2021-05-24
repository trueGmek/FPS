using System.Collections;
using UnityEngine;
using Grid = Systems.Grid;

namespace Weapons {
    [RequireComponent(typeof(Gun))]
    public class RaycastShoot : MonoBehaviour {
        public float shootDuration;

        private float _nextFireTime;

        private Camera _mainCamera;
        private WaitForSeconds _shootDuration;
        private AudioSource _gunAudio;
        private LineRenderer _laserLine;
        private Gun _gun;

        private void Awake() {
            Grid.InputManager.ONShootTriggered += ShootAction;
        }

        private void Start() {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
            _gun = GetComponent<Gun>();


            _mainCamera = Camera.main;
            _shootDuration = new WaitForSeconds(shootDuration);
        }

        private void ShootAction() {
            if (Time.time > _nextFireTime) {
                _nextFireTime = Time.time + _gun.fireRate;

                StartCoroutine(ShotEffects());

                Vector3 middleOfTheScreen = new Vector3(0.5f, 0.5f, 0.5f);
                Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(middleOfTheScreen);

                if (Physics.Raycast(rayOrigin, _mainCamera.transform.forward, out var hit, _gun.weaponRange)) {
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
                shootableObject.Hit(new HitData(hit.normal, _gun.hitForce, _gun.damage));
            }
        }

        private void SetLaserPositionsOnMiss() {
            _laserLine.SetPosition(0, _gun.gunEnd.position);
            _laserLine.SetPosition(1, _mainCamera.transform.forward * _gun.weaponRange);
        }

        private void SetLaserPositionOnHit(RaycastHit hit) {
            _laserLine.SetPosition(0, _gun.gunEnd.position);
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