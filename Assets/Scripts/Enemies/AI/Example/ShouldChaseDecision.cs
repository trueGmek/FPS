using Systems.StateMachine;
using UnityEngine;

namespace Enemies.AI.Example {
    [CreateAssetMenu(menuName = "AI/Example/Decision/ShouldChaseDecision")]
    public class ShouldChaseDecision : Decision {
        public override bool Decide(StateController controller) {
            bool targetVisible = IsTargetVisible(controller);
            return targetVisible;
        }

        private static bool IsTargetVisible(StateController controller) {
            Collider[] playerColliders = new Collider[1];
            Physics.OverlapSphereNonAlloc(controller.body.position, controller.eyesightRange, playerColliders,
                controller.playerLayer);
            if (playerColliders[0] != null) {
                controller.chaseTransform = playerColliders[0].transform;
                return true;
            }

            return false;
        }
    }
}