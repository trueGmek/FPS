using System;
using UnityEngine;

namespace Weapons {
    public class RaycastShootViewer : MonoBehaviour {
        public float weaponRange = 50f;

        private Camera _fpsCamera;

        void Start() {
            _fpsCamera = Camera.main;
        }

        private void Update() {
            Vector3 lineOrigin = _fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(lineOrigin, _fpsCamera.transform.forward * weaponRange, Color.green);
        }
    }
}