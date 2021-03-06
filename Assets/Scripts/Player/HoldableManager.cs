using Items;
using UI;
using UnityEditor.ShaderGraph;
using UnityEngine;
using Weapons;
using Grid = Systems.Grid;

namespace Player {
    public class HoldableManager : MonoBehaviour {
        private IHoldable _currentHoldable;

        [Header("In game weapon prefabs")] public GameObject pistol;
        public GameObject shotgun;
        public GameObject assaultRifle;

        public AmmunitionDisplay ammunitionDisplay;

        private InputManager _inputManager;

        private GameObject _currentHoldableGameObject;

        private void Awake() {
            _inputManager = Grid.InputManager;
        }

        private void Start() {
            SubscribeToInputManagerEvents();

            _inputManager.ONWeapon1Triggered += EquipPistol;
            _inputManager.ONWeapon2Triggered += EquipShotgun;
            _inputManager.ONWeapon3Triggered += EquipAssaultRiffle;
        }

        private void EquipPistol() {
            EquipHoldable(pistol);
            ammunitionDisplay.gameObject.SetActive(true);
        }

        private void EquipShotgun() {
            EquipHoldable(shotgun);
            ammunitionDisplay.gameObject.SetActive(true);
        }

        private void EquipAssaultRiffle() {
            EquipHoldable(assaultRifle);
            ammunitionDisplay.gameObject.SetActive(true);
        }

        private void EquipHoldable(GameObject item) {
            UnsubscribeToInputManagerEvents();
            DestroyCurrentHoldable();
            _currentHoldableGameObject = InstantiateAtProperPosition(item);
            SwapItemsAndSubscriptions(_currentHoldableGameObject.GetComponent<IHoldable>());
        }

        private GameObject InstantiateAtProperPosition(GameObject item) {
            GameObject newGameObject = Instantiate(item, transform);
            newGameObject.transform.localPosition = new Vector3(0, 0, 0);
            return newGameObject;
        }

        private void SwapItemsAndSubscriptions(IHoldable holdablePistol) {
            SwapCurrentItem(holdablePistol);
            SubscribeToInputManagerEvents();
        }

        private void DestroyCurrentHoldable() {
            Destroy(_currentHoldableGameObject);
        }

        private void SwapCurrentItem(IHoldable newItem) {
            SetNewCurrentItem(newItem);
            var weapon = _currentHoldableGameObject.GetComponent<RangedWeapon>();
            weapon.SetAmmunitionDisplay(ammunitionDisplay, weapon.Ammunition);
            _currentHoldable.Initialize();
        }

        private void SetNewCurrentItem(IHoldable newItem) {
            _currentHoldable = newItem;
        }

        private void SubscribeToInputManagerEvents() {
            if (_currentHoldable != null) {
                _inputManager.ONShootStarted += _currentHoldable.OnLeftButtonPressed;
                _inputManager.ONShootCanceled += _currentHoldable.OnLeftButtonReleased;
                _inputManager.ONReloadTriggered += _currentHoldable.OnReloadTriggered;
            }
        }

        private void UnsubscribeToInputManagerEvents() {
            if (_currentHoldable != null) {
                _inputManager.ONShootStarted -= _currentHoldable.OnLeftButtonPressed;
                _inputManager.ONShootCanceled -= _currentHoldable.OnLeftButtonReleased;
                _inputManager.ONReloadTriggered -= _currentHoldable.OnReloadTriggered;
            }
        }
    }
}