using Systems.StateMachine;
using UnityEngine;

namespace Enemies.AI.Example {
    [CreateAssetMenu(fileName = "ChaseAction", menuName = "AI/Example/Actions/Chase")]
    public class ChaseAction : Action {
        public override void Act(StateController controller) {
            controller.navMeshAgent.destination = controller.chaseTransform.position;
            controller.navMeshAgent.stoppingDistance = controller.attackRange;
            if (controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance) {
                Debug.Log("GOT YA!");
            }
        }
    }
}