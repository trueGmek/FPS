using UnityEngine;
using UnityEngine.AI;

namespace Enemies.Movement {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Zombie : MonoBehaviour {
        public Transform player;
        private NavMeshAgent _agent;

        private void Start() {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update() {
            _agent.destination = player.transform.position;
        }
    }
}