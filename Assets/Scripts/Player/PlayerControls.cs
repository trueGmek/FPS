// GENERATED AUTOMATICALLY FROM 'Assets/Settings/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2bc2c1d2-bf03-473d-bda5-37fcb7adb587"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f4075e08-470a-49aa-be25-09777877925c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""bed7897e-56d0-4ca4-839a-dd5ab2b967b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0bbef9d0-1151-4c05-a9e1-810bc35fd1cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""f14b2f41-775a-4044-9579-64ba6d1fe76b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6283da18-7ec7-4041-9647-4173411af57c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectWeapon1"",
                    ""type"": ""Button"",
                    ""id"": ""411ef03a-7e25-48b1-94cb-c02165281d43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectWeapon2"",
                    ""type"": ""Button"",
                    ""id"": ""7ae940dd-30d9-4e95-b8a0-ee2a25486166"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectWeapon3"",
                    ""type"": ""Button"",
                    ""id"": ""76d49ad3-6415-4036-bba8-8089e0a5035e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""c081b65c-07b7-446f-b658-96d80204f6b9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe750e7b-2185-43f8-b2e1-553114998cac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d744ada-bde0-44e5-90ed-76b67fc9a111"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""af0d58b7-13af-4dc6-9ea5-f5cb8b5f6040"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""97b520a1-7eab-4b53-9a99-77bff4792072"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""366b27ee-0567-4769-a70e-5dc805dcd726"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9507a92b-5b9a-4270-8d86-5f44bd9cd373"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fe57c77-2975-47cd-b826-fee2f782a9ab"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47736181-84ed-4dc0-b5c2-103413f037c1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79fb9e80-a780-44a6-9ddc-01c6969a1250"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectWeapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a938efc3-4d7c-4687-b85c-646857a65b04"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectWeapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""042d3c54-87a9-4b5d-b59e-ede85bfef17a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectWeapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            m_Player_SelectWeapon1 = m_Player.FindAction("SelectWeapon1", throwIfNotFound: true);
            m_Player_SelectWeapon2 = m_Player.FindAction("SelectWeapon2", throwIfNotFound: true);
            m_Player_SelectWeapon3 = m_Player.FindAction("SelectWeapon3", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Shoot;
        private readonly InputAction m_Player_Interact;
        private readonly InputAction m_Player_SelectWeapon1;
        private readonly InputAction m_Player_SelectWeapon2;
        private readonly InputAction m_Player_SelectWeapon3;
        public struct PlayerActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_Player_Look;
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputAction @SelectWeapon1 => m_Wrapper.m_Player_SelectWeapon1;
            public InputAction @SelectWeapon2 => m_Wrapper.m_Player_SelectWeapon2;
            public InputAction @SelectWeapon3 => m_Wrapper.m_Player_SelectWeapon3;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                    @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @SelectWeapon1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon1;
                    @SelectWeapon1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon1;
                    @SelectWeapon1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon1;
                    @SelectWeapon2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon2;
                    @SelectWeapon2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon2;
                    @SelectWeapon2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon2;
                    @SelectWeapon3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon3;
                    @SelectWeapon3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon3;
                    @SelectWeapon3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectWeapon3;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @SelectWeapon1.started += instance.OnSelectWeapon1;
                    @SelectWeapon1.performed += instance.OnSelectWeapon1;
                    @SelectWeapon1.canceled += instance.OnSelectWeapon1;
                    @SelectWeapon2.started += instance.OnSelectWeapon2;
                    @SelectWeapon2.performed += instance.OnSelectWeapon2;
                    @SelectWeapon2.canceled += instance.OnSelectWeapon2;
                    @SelectWeapon3.started += instance.OnSelectWeapon3;
                    @SelectWeapon3.performed += instance.OnSelectWeapon3;
                    @SelectWeapon3.canceled += instance.OnSelectWeapon3;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnSelectWeapon1(InputAction.CallbackContext context);
            void OnSelectWeapon2(InputAction.CallbackContext context);
            void OnSelectWeapon3(InputAction.CallbackContext context);
        }
    }
}
