using UnityEngine;

namespace Player {
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour {
        [SerializeField, Range(0f, 5f)] private float jumpHeight = 1.0f;
        [SerializeField, Range(0f, 5f)] private float playerSpeed = 2.0f;
        [SerializeField, Range(0f, 5f)] private float rayCastLength = 1f;
        [SerializeField, Range(0f, 1f)] private float maxTimeFromJumpTriggerTillContact;
        [SerializeField] private InputManager inputManager;

        private readonly float _gravityValue = Physics.gravity.y;

        private CharacterController _controller;
        private Transform _cameraTransform;

        private Vector3 _playerCurrentVelocity;
        private bool _isPlayerGrounded = true;

        private bool _shouldJump;
        private float _timeSinceLastJumpButtonPress;

        private void OnEnable() {
            SetUpReferences();
        }

        private void SetUpReferences() {
            _controller = GetComponent<CharacterController>();
            ManageCameraReference();
        }

        private void Start() {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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

            EvaluateJumpIntention();
            if (_shouldJump) {
                Jump();
            }

            _playerCurrentVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerCurrentVelocity * Time.deltaTime);
        }

        private void CheckIfPlayerStaysOnGround() {
            Ray ray = new Ray(transform.position, Vector3.down);
            _isPlayerGrounded = Physics.Raycast(ray, out _, _controller.bounds.extents.y + rayCastLength);
        }

        private void EvaluateJumpIntention() {
            _shouldJump |= inputManager.WasJumpTriggered();
            _timeSinceLastJumpButtonPress += Time.deltaTime;

            if (!(_timeSinceLastJumpButtonPress >= maxTimeFromJumpTriggerTillContact) || _isPlayerGrounded) return;
            _shouldJump = false;
            _timeSinceLastJumpButtonPress = 0f;
        }

        private void Jump() {
            _playerCurrentVelocity.y += Mathf.Sqrt(-2f * jumpHeight * _gravityValue);
        }
    }
}