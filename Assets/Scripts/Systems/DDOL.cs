using UnityEngine;

namespace Systems {
    public class DDOL : MonoBehaviour {
        public void Awake() {
            DontDestroyOnLoad(gameObject);
        }
    }
}