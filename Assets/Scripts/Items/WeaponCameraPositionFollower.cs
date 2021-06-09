using UnityEngine;
using Utils;

namespace Items {
    public class WeaponCameraPositionFollower : MonoBehaviour {
        public Vector3 offsetVector;
        public FloatVariable range;

        private Camera _camera;


        private void Start() {
            _camera = Camera.main;
        }

        private void Update() {
            var cameraTransform = _camera.transform;

            // ReSharper disable once InconsistentNaming
            var _transform = transform;
            _transform.position = cameraTransform.position +
                                  cameraTransform.forward * offsetVector.z +
                                  cameraTransform.right * offsetVector.x + cameraTransform.up * offsetVector.y;
            
            _transform.LookAt(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, range.value)));
        }
    }
}