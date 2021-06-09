using Items;
using UnityEngine;
using Weapons;
using Grid = Systems.Grid;

namespace Player {
    public class HoldableManager : MonoBehaviour {
        public IHoldable CurrentHoldable;

        [Header("In game weapon prefabs")] public GameObject pistol;
        public GameObject shotgun;

        private InputManager _inputManager;

        private GameObject _currentHoldableGameObject;

        private void Awake() {
            _inputManager = Grid.InputManager;
        }

        private void Start() {
            SubscribeToInputManagerEvents();

            _inputManager.ONWeapon1Triggered += EquipPistol;
            _inputManager.ONWeapon2Triggered += EquipShotgun;
        }

        private void EquipPistol() {
            EquipHoldable(pistol);
        }

        private void EquipShotgun() {
            EquipHoldable(shotgun);
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
            CurrentHoldable.Initialize();
        }

        private void SetNewCurrentItem(IHoldable newItem) {
            CurrentHoldable = newItem;
        }

        private void SubscribeToInputManagerEvents() {
            if (CurrentHoldable != null) {
                _inputManager.ONShootTriggered += CurrentHoldable.OnLeftButtonClick;
            }
        }

        private void UnsubscribeToInputManagerEvents() {
            if (CurrentHoldable != null) {
                _inputManager.ONShootTriggered -= CurrentHoldable.OnLeftButtonClick;
            }
        }
    }
}