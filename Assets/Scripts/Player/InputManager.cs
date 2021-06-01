using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class InputManager : MonoBehaviour {
        private PlayerControls _playerControls;

        public event Action ONShootTriggered;
        public event Action ONJumpTriggered;

        public event Action ONInteractTriggered;

        private void Awake() {
            _playerControls = new PlayerControls();

            SetEventCallbacks();
        }

        private void SetEventCallbacks() {
            _playerControls.Player.Shoot.performed += OnPlayerControlsPlayerShootTriggered;
            _playerControls.Player.Jump.performed += OnPlayerControlsPlayerJumpTriggered;
            _playerControls.Player.Interact.performed += OnPlayerControlsPlayerInteractTriggered;
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

        private void OnPlayerControlsPlayerShootTriggered(InputAction.CallbackContext callbackContext) {
            ONShootTriggered?.Invoke();
        }

        private void OnPlayerControlsPlayerJumpTriggered(InputAction.CallbackContext callbackContext) {
            ONJumpTriggered?.Invoke();
        }

        private void OnPlayerControlsPlayerInteractTriggered(InputAction.CallbackContext callbackContext) {
            ONInteractTriggered?.Invoke();
        }
    }
}