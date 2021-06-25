using Items;
using UI;
using UnityEngine;
using Grid = Systems.Grid;

namespace Weapons {
    public abstract class RangedWeapon : MonoBehaviour, IHoldable {
        private AmmunitionDisplay _ammunitionDisplay;

        public void SetAmmunitionDisplay(AmmunitionDisplay ammunitionDisplay, Ammunition ammunition) {
            _ammunitionDisplay = ammunitionDisplay;
            Grid.InputManager.ONReloadTriggered += ammunition.Reload;
            _ammunitionDisplay.Ammunition = ammunition;
        }


        public abstract void Initialize();
        public abstract Ammunition Ammunition { get; }
        public abstract void OnLeftButtonPressed();
        public abstract void OnLeftButtonReleased();
        public abstract void OnRightButtonPressed();
        public abstract void OnRightButtonReleased();

        public abstract void OnReloadTriggered();
    }
}