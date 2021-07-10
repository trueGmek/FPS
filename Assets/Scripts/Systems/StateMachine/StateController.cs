using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace Systems.StateMachine {
    public class StateController : MonoBehaviour {
        public State currentState;
        public Transform[] waypoints;
        public NavMeshAgent navMeshAgent;
        public float debugSphereRadius = 1;
        [HideInInspector] public Transform chaseTransform;
        public LayerMask playerLayer;
        public float eyesightRange;
        public float attackRange;
        public Transform body;

        public bool aiActive;


        private void Update() {
            if (!aiActive) {
                return;
            }

            currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState) {
            Assert.IsNotNull(nextState);
            Assert.AreNotEqual(currentState, nextState);
            currentState = nextState;
        }

        private void OnDrawGizmos() {
            if (currentState == null) return;
            Gizmos.color = currentState.sceneGizmoColor;
            var position = navMeshAgent.transform.position;
            Gizmos.DrawSphere(position, debugSphereRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(position, eyesightRange);
        }
    }
}