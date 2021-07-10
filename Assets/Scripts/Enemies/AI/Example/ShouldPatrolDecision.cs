using Systems.StateMachine;
using UnityEngine;

namespace Enemies.AI.Example {
    [CreateAssetMenu(menuName = "AI/Example/Decision/ShouldPatrolDecision", fileName = "ShouldPatrolDecision")]
    public class ShouldPatrolDecision : Decision {
        public override bool Decide(StateController controller) {
            Collider[] playerColliders = new Collider[1];
            Physics.OverlapSphereNonAlloc(controller.body.position, controller.eyesightRange,
                playerColliders, controller.playerLayer);
            return playerColliders[0] == null;
        }
    }
}