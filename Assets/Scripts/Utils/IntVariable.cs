using UnityEngine;

namespace Utils {
    [CreateAssetMenu(fileName = "Int", menuName = "Variables/Int", order = 0)]
    public class IntVariable : ScriptableObject {
        public int value;
    }
}