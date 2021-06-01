using Items;
using UnityEngine;
using Weapons;
using Grid = Systems.Grid;

namespace Player {
    public class HoldableManager : MonoBehaviour {
        public IHoldable CurrentItem;
        public GameObject pistol;

        private InputManager _inputManager;

        private void Awake() {
            _inputManager = Grid.InputManager;
        }

        private void Start() {
            SubscribeToInputManagerEvents();

            _inputManager.ONInteractTriggered += EquipPistol;
        }

        private void EquipPistol() {
            var pistolObject = InstantiateAtProperPosition();
            SwapItemsAndSubscriptions(pistolObject.GetComponent<IHoldable>());
        }

        private GameObject InstantiateAtProperPosition() {
            var pistolGameObject = Instantiate(pistol, transform);
            pistolGameObject.transform.localPosition = new Vector3(0, 0, 0);
            return pistolGameObject;
        }

        private void SwapItemsAndSubscriptions(IHoldable holdablePistol) {
            UnsubscribeToInputManagerEvents();
            SwapCurrentItem(holdablePistol);
            SubscribeToInputManagerEvents();
        }

        private void SwapCurrentItem(IHoldable newItem) {
            SetNewCurrentItem(newItem);
            CurrentItem.Initialize();
        }

        private void SetNewCurrentItem(IHoldable newItem) {
            CurrentItem = newItem;
        }

        private void SubscribeToInputManagerEvents() {
            if (CurrentItem != null) {
                _inputManager.ONShootTriggered += CurrentItem.OnLeftButtonClick;
            }
        }

        private void UnsubscribeToInputManagerEvents() {
            if (CurrentItem != null) {
                _inputManager.ONShootTriggered -= CurrentItem.OnLeftButtonClick;
            }
        }
    }
}