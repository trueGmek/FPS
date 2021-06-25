using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class InputManager : MonoBehaviour {
        private PlayerControls _playerControls;

        public event Action ONShootStarted;
        public event Action ONShootTriggered;
        public event Action ONShootCanceled;
        public event Action ONJumpTriggered;
        public event Action ONInteractTriggered;
        public event Action ONReloadTriggered;
        public event Action ONWeapon1Triggered;
        public event Action ONWeapon2Triggered;
        public event Action ONWeapon3Triggered;

        private void Awake() {
            _playerControls = new PlayerControls();
            SetEventCallbacks();
        }

        private void SetEventCallbacks() {
            _playerControls.Player.Shoot.performed += OnPlayerControlsPlayerShootTriggered;
            _playerControls.Player.Shoot.started += OnPlayerControlsPlayerShootStarted;
            _playerControls.Player.Shoot.canceled += OnPlayerControlsPlayerShootCanceled;
            _playerControls.Player.Jump.performed += OnPlayerControlsPlayerJumpTriggered;
            _playerControls.Player.Interact.performed += OnPlayerControlsPlayerInteractTriggered;
            _playerControls.Player.Reload.performed += OnPlayerControlsPlayerReloadTriggered;
            _playerControls.Player.SelectWeapon1.performed += OnPlayerControlsPlayerSelectWeapon1Triggered;
            _playerControls.Player.SelectWeapon2.performed += OnPlayerControlsPlayerSelectWeapon2Triggered;
            _playerControls.Player.SelectWeapon3.performed += OnPlayerControlsPlayerSelectWeapon3Triggered;
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

        private void OnPlayerControlsPlayerShootTriggered(InputAction.CallbackContext callbackContext) {
            ONShootTriggered?.Invoke();
        }

        private void OnPlayerControlsPlayerJumpTriggered(InputAction.CallbackContext callbackContext) {
            ONJumpTriggered?.Invoke();
        }

        private void OnPlayerControlsPlayerInteractTriggered(InputAction.CallbackContext callbackContext) {
            ONInteractTriggered?.Invoke();
        }

        private void OnPlayerControlsPlayerReloadTriggered(InputAction.CallbackContext callbackContext) {
            ONReloadTriggered?.Invoke();
        }

        private void OnPlayerControlsPlayerSelectWeapon1Triggered(InputAction.CallbackContext callbackContext) {
            ONWeapon1Triggered?.Invoke();
        }

        private void OnPlayerControlsPlayerSelectWeapon2Triggered(InputAction.CallbackContext callbackContext) {
            ONWeapon2Triggered?.Invoke();
        }

        private void OnPlayerControlsPlayerSelectWeapon3Triggered(InputAction.CallbackContext callbackContext) {
            ONWeapon3Triggered?.Invoke();
        }

        private void OnPlayerControlsPlayerShootStarted(InputAction.CallbackContext callbackContext) {
            ONShootStarted?.Invoke();
        }

        private void OnPlayerControlsPlayerShootCanceled(InputAction.CallbackContext callbackContext) {
            ONShootCanceled?.Invoke();
        }
    }
}