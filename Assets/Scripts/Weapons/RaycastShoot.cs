using System;
using System.Collections;
using System.Net;
using Player;
using UnityEngine;

namespace Weapons {
    public class RaycastShoot : MonoBehaviour {
        public int gunDamage = 1;

        public float fireRate = 0.25f;
        public float weaponRange = 50f;
        public float hitForce = 100f;

        public Transform gunEnd;

        public InputManager inputManager; //TODO:REMOVE THE COMPONENT TO _preload SCENE AND REFERENCE THIS FROM THERE

        private Camera _fpsCamera;
        private WaitForSeconds _shootDuration = new WaitForSeconds(0.07f);
        private AudioSource _gunAudio;
        private LineRenderer _laserLine;
        private float _nextFire;

        private void Start() {
            _laserLine = GetComponent<LineRenderer>();
            _gunAudio = GetComponent<AudioSource>();
            _fpsCamera = Camera.main;
        }

        private void Update() {
            if (inputManager.WasFireTriggered() && Time.time > _nextFire) {
                _nextFire = Time.time + fireRate;
                StartCoroutine(ShotEffect());
                Vector3 rayOrigin = _fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                _laserLine.SetPosition(0, gunEnd.position);
                if (Physics.Raycast(rayOrigin, _fpsCamera.transform.forward, out hit, weaponRange)) {
                    _laserLine.SetPosition(1, hit.point);
                    Shootable shootableObject = hit.collider.GetComponent<Shootable>();
                    if (shootableObject != null) {
                        shootableObject.ApplyDamage(gunDamage);
                    }

                    if (hit.rigidbody != null) {
                        hit.rigidbody.AddForce(-hit.normal * hitForce);
                    }
                }
                else {
                    _laserLine.SetPosition(1, _fpsCamera.transform.forward * weaponRange);
                }
            }
        }

        private IEnumerator ShotEffect() {
            _gunAudio.Play();
            _laserLine.enabled = true;

            yield return _shootDuration;

            _laserLine.enabled = false;
        }
    }
}