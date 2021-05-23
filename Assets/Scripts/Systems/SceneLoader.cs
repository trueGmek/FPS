using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems {
    public class SceneLoader : MonoBehaviour {
        public string sceneName;


        private void Start() {
            SceneManager.LoadScene(sceneName);
        }
    }
}