using UnityEngine;
using Utils;

namespace Weapons.Shotgun {
    public class RaycastConeShootViewer : MonoBehaviour {
        public FloatVariable range;
        public float circleRadius = 2;
        public float numberOfProjectiles;

        private Camera _camera;
        private GunEnd _gunEnd;

        private void Start() {
            _camera = Camera.main;
            _gunEnd = GetComponentInChildren<GunEnd>();
        }

        private void OnDrawGizmos() {
            DrawRayToTheCenterOfTheCircle();
            VisualizeProjectiles();
        }

        private void DrawRayToTheCenterOfTheCircle() {
            Gizmos.color = Color.blue;
            Vector3 lineOrigin = _gunEnd.transform.position;
            Vector3 lineEnd = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, range.value));
            Gizmos.DrawSphere(lineOrigin, 0.1f);
            Gizmos.DrawSphere(lineEnd, 0.1f);
            Gizmos.DrawLine(lineOrigin, lineEnd);
        }

        private void VisualizeProjectiles() {
            Gizmos.color = Color.green;
            Vector3 lineEnd = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, range.value));
            for (int i = 0; i < numberOfProjectiles; i++) {
                var positionOnUnitCircle = Random.insideUnitCircle * circleRadius;
                var pointPosition = lineEnd + Quaternion.Euler(_camera.transform.rotation.eulerAngles) *
                    new Vector3(positionOnUnitCircle.x, positionOnUnitCircle.y, 0f);
                Gizmos.DrawSphere(pointPosition, 0.1f);
                Gizmos.DrawLine(_gunEnd.transform.position, pointPosition);
            }
        }
    }
}