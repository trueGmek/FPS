using UnityEngine;

namespace Systems.StateMachine {
    [CreateAssetMenu(menuName = "AI/State")]
    public class State : ScriptableObject {
        public Action[] actions;
        public Transition[] transitions;

        public Color sceneGizmoColor = Color.gray;

        public void UpdateState(StateController controller) {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(StateController controller) {
            foreach (var action in actions) {
                action.Act(controller);
            }
        }

        private void CheckTransitions(StateController controller) {
            foreach (Transition transition in transitions) {
                bool decisionSucceeded = transition.decision.Decide(controller);
                if (decisionSucceeded) {
                    controller.TransitionToState(transition.stateToTransition);
                }
            }
        }
    }
}