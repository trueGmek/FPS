using UnityEngine;

namespace Player {
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour {
        [SerializeField, Range(0f, 5f)] private float jumpHeight = 1.0f;
        [SerializeField, Range(0f, 5f)] private float playerSpeed = 2.0f;
        [SerializeField, Range(0f, 5f)] private float rayCastLength = 1f;
        [SerializeField] private InputManager inputManager;

        private readonly float _gravityValue = Physics.gravity.y;

        private CharacterController _controller;
        private Transform _cameraTransform;

        private Vector3 _playerCurrentVelocity;
        private bool _isPlayerGrounded = true;

        private void OnEnable() {
            SetUpReferences();
        }

        private void Start() {
            Cursor.visible = false;
        }

        private void SetUpReferences() {
            _controller = GetComponent<CharacterController>();
            ManageCameraReference();
        }

        private void ManageCameraReference() {
            if (Camera.main != null) {
                _cameraTransform = Camera.main.transform;
            }
            else {
                Debug.LogError("Main Camera component does not exit!");
            }
        }

        private void Update() {
            MovePlayer();
        }

        private void MovePlayer() {
            HandleHorizontalMovement();
            HandleVerticalMovement();
        }

        private void HandleHorizontalMovement() {
            Vector2 keyboardInput = inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(keyboardInput.x, 0f, keyboardInput.y);

            move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
            move.y = 0;
            move = move.normalized;
            move *= playerSpeed;

            _controller.Move(move * Time.deltaTime);
        }

        private void HandleVerticalMovement() {
            _isPlayerGrounded = _controller.isGrounded;
            if (_isPlayerGrounded && _playerCurrentVelocity.y < 0) {
                _playerCurrentVelocity.y = 0f;
            }

            Jump();

            _playerCurrentVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerCurrentVelocity * Time.deltaTime);
        }

        private void Jump() {
            float distanceToGround = _controller.bounds.extents.y;
            Ray ray = new Ray(transform.position, Vector3.down);
            if (inputManager.WasJumpTriggered() && Physics.Raycast(ray, out _, distanceToGround + rayCastLength)) {
                _playerCurrentVelocity.y += Mathf.Sqrt(-2f * jumpHeight * _gravityValue);
            }
        }
    }
}