using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace UI {
    public class AmmunitionDisplay : MonoBehaviour {
        private Text _text;
        private Ammunition _ammunition;

        private void Awake() {
            _text = GetComponentInChildren<Text>();
        }

        public Ammunition Ammunition {
            set => _ammunition = value;
        }

        private void Update() {
            SetAmmunitionText();
        }

        private void SetAmmunitionText() {
            _text.text = $"{_ammunition.AmmunitionInMagazine}/{_ammunition.AdditionalAmmunition}";
        }
    }
}