namespace Items {
    public interface IHoldable {
        void Initialize();
        void OnLeftButtonPressed();
        void OnLeftButtonReleased();

        void OnRightButtonPressed();
        void OnRightButtonReleased();

        void OnReloadTriggered();
    }
}