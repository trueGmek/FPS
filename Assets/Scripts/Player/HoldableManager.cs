using Items;
using UnityEngine;
using Grid = Systems.Grid;

namespace Player {
    public class HoldableManager : MonoBehaviour {
        private IHoldable _currentHoldable;

        [Header("In game weapon prefabs")] public GameObject pistol;
        public GameObject shotgun;
        public GameObject assaultRifle;

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
        }

        private void EquipShotgun() {
            EquipHoldable(shotgun);
        }

        private void EquipAssaultRiffle() {
            EquipHoldable(assaultRifle);
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
            _currentHoldable.Initialize();
        }

        private void SetNewCurrentItem(IHoldable newItem) {
            _currentHoldable = newItem;
        }

        private void SubscribeToInputManagerEvents() {
            if (_currentHoldable != null) {
                _inputManager.ONShootStarted += _currentHoldable.OnLeftButtonPressed;
                _inputManager.ONShootCanceled += _currentHoldable.OnLeftButtonReleased;
            }
        }

        private void UnsubscribeToInputManagerEvents() {
            if (_currentHoldable != null) {
                _inputManager.ONShootStarted -= _currentHoldable.OnLeftButtonPressed;
                _inputManager.ONShootCanceled -= _currentHoldable.OnLeftButtonReleased;
            }
        }
    }
}