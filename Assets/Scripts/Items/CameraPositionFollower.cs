using UnityEngine;

namespace Items {
    public class CameraPositionFollower : MonoBehaviour {
        public Vector3 offsetVector;
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
            _transform.rotation = cameraTransform.rotation;
        }
    }
}