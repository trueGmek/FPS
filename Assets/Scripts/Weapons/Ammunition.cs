using UnityEngine;
using Grid = Systems.Grid;

namespace Weapons {
    [CreateAssetMenu(fileName = "Ammunition", menuName = "Weapons/Ammunition", order = 0)]
    public class Ammunition : ScriptableObject {
        public uint initialAmmunitionInMagazine;
        public uint initialAdditionalAmmunition;
        public uint magazineSize;
        public uint maximalAdditionalAmmunition;


        private uint _ammunitionInMagazine;
        private uint _additionalAmmunition;

        public uint AmmunitionInMagazine => _ammunitionInMagazine;
        public uint AdditionalAmmunition => _additionalAmmunition;

        private void OnValidate() {
            _ammunitionInMagazine = initialAmmunitionInMagazine;
            _additionalAmmunition = initialAdditionalAmmunition;
        }


        public bool HasAmmunitionInMagazine() {
            return _ammunitionInMagazine > 0;
        }

        public void Shoot() {
            _ammunitionInMagazine -= 1;
        }

        public bool CanReload() {
            return _additionalAmmunition > 0 && _ammunitionInMagazine < magazineSize;
        }

        public void Reload() {
            var numberOfBulletsMissingInMagazine = magazineSize - _ammunitionInMagazine;
            if (_additionalAmmunition > numberOfBulletsMissingInMagazine) {
                _ammunitionInMagazine += numberOfBulletsMissingInMagazine;
                _additionalAmmunition -= numberOfBulletsMissingInMagazine;
            }
            else {
                _ammunitionInMagazine += _additionalAmmunition;
                _additionalAmmunition = 0;
            }
        }

        public bool CanPickUpAmmo() {
            return _additionalAmmunition < maximalAdditionalAmmunition;
        }

        public void PickUpAmmunition(uint numberOfBullets) {
            _additionalAmmunition += numberOfBullets;
        }
    }
}