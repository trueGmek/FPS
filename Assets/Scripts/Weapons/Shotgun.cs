using Items;
using UnityEngine;

namespace Weapons {
    public class Shotgun : MonoBehaviour, IHoldable {
        public GameObject shotgunModel;

        public void Initialize() {
            Instantiate(shotgunModel, transform);
        }

        public void OnLeftButtonClick() {
            Debug.Log("POW");
        }


        public void OnRightButtonClick() {
            throw new System.NotImplementedException();
        }
    }
}