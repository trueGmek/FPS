using Systems.StateMachine;
using UnityEngine;

namespace Enemies.AI.Example {
    [CreateAssetMenu(menuName = "AI/Example/Actions/Patrol")]
    public class PatrolAction : Action {
        public float stoppingDistanceToWaypoint = 0.01f;
        private int _patrolWaypointIndex;


        public override void Act(StateController controller) {
            Patrol(controller);
        }

        private void Patrol(StateController controller) {
            controller.navMeshAgent.stoppingDistance = stoppingDistanceToWaypoint;
            controller.navMeshAgent.destination = controller.waypoints[_patrolWaypointIndex].position;
            controller.navMeshAgent.isStopped = false;

            if (controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance &&
                !controller.navMeshAgent.pathPending) {
                _patrolWaypointIndex = (_patrolWaypointIndex + 1) % controller.waypoints.Length;
            }
        }
    }
}