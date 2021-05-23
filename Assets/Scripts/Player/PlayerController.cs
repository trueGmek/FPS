using UnityEngine;
using Grid = Systems.Grid;

namespace Player {
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour {
        [SerializeField, Range(0f, 5f)] private float jumpHeight = 1.0f;
        [SerializeField, Range(0f, 5f)] private float playerSpeed = 2.0f;
        [SerializeField, Range(0f, 5f)] private float rayCastLength = 1f;

        private readonly float _gravityValue = Physics.gravity.y;

        private CharacterController _controller;
        private Transform _cameraTransform;

        private Vector3 _playerCurrentVelocity;
        private bool _isPlayerGrounded = true;


        private void OnEnable() {
            SetUpReferences();
            Grid.InputManager.ONJumpTriggered += JumpAction;
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

        private void JumpAction() {
            if (_isPlayerGrounded) {
                Jump();
            }
        }

        private void Jump() {
            _playerCurrentVelocity.y += Mathf.Sqrt(-2f * jumpHeight * _gravityValue);
        }

        private void Start() {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update() {
            MovePlayer();
        }

        private void MovePlayer() {
            HandleHorizontalMovement();
            HandleVerticalMovement();
        }

        private void HandleHorizontalMovement() {
            Vector2 keyboardInput = Grid.InputManager.GetPlayerMovement();
            Vector3 keyboardToWorld = new Vector3(keyboardInput.x, 0f, keyboardInput.y);

            Vector3 displacementVector = _cameraTransform.forward * keyboardToWorld.z +
                                         _cameraTransform.right * keyboardToWorld.x;
            displacementVector.y = 0;
            displacementVector.Normalize();
            displacementVector *= playerSpeed;

            _controller.Move(displacementVector * Time.deltaTime);
        }

        private void HandleVerticalMovement() {
            CheckIfPlayerStaysOnGround();

            if (_isPlayerGrounded && _playerCurrentVelocity.y < 0) {
                _playerCurrentVelocity.y = 0f;
            }

            _playerCurrentVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerCurrentVelocity * Time.deltaTime);
        }

        private void CheckIfPlayerStaysOnGround() {
            Ray ray = new Ray(transform.position, Vector3.down);
            _isPlayerGrounded = Physics.Raycast(ray, out _, _controller.bounds.extents.y + rayCastLength);
        }
    }
}