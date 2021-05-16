using UnityEngine;

namespace Player {
    public class InputManager : MonoBehaviour {
        private PlayerControls _playerControls;

        private void Awake() {
            _playerControls = new PlayerControls();
        }

        private void OnEnable() {
            _playerControls.Enable();
        }

        private void OnDisable() {
            _playerControls.Disable();
        }

        public Vector2 GetPlayerMovement() {
            return _playerControls.Player.Move.ReadValue<Vector2>();
        }

        public bool WasJumpTriggered() {
            return _playerControls.Player.Jump.triggered;
        }

        public bool WasFireTriggered() {
            return _playerControls.Player.Shoot.triggered;
        }
    }
}