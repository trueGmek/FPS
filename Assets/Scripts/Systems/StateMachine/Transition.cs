namespace Systems.StateMachine {
    [System.Serializable]
    public class Transition {
        public Decision decision;
        public State stateToTransition;
    }
}