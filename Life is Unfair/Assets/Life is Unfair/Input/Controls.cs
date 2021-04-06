// GENERATED AUTOMATICALLY FROM 'Assets/Life is Unfair/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LifeIsUnfair.Input
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c34d954e-53c6-48d8-99e6-dfdc17b35261"",
            ""actions"": [
                {
                    ""name"": ""Horizontal Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e4f0e557-8022-4c7f-97d3-c1fc8887c0d0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a3a05e0f-bf02-4790-b4c5-6aa9fca001aa"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1ab8d348-5fee-4ee8-a0d0-e352f82f7a67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""882b1a33-c474-432e-b1bd-439ea26c93f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""e24dc4af-aa36-484c-8e8b-aa1b048e704c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD Keys"",
                    ""id"": ""f9bb16ac-9603-400b-8444-ab1eb3642d37"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0d769a60-1c76-4c17-afa9-430bbaa58d15"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b3e572da-a01a-4f9b-8d23-98074bba60c2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3d808b47-fc08-429e-84df-634a389608e1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""SW Keys"",
                    ""id"": ""bae58ffd-3eae-4492-b0fa-f23d399304cc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b85e9cd3-94c3-48c1-a36e-d2f2d17c74ab"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d080f671-24c5-4607-a2ad-c92f11d18a71"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a0c8f64c-2b54-44e6-a5aa-cbd9bbd6b6e8"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ae576fb-e91a-47b7-88c7-a99d0ed1570d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
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
            m_Player_HorizontalMovement = m_Player.FindAction("Horizontal Movement", throwIfNotFound: true);
            m_Player_VerticalMovement = m_Player.FindAction("Vertical Movement", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
            m_Player_Resume = m_Player.FindAction("Resume", throwIfNotFound: true);
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
        private readonly InputAction m_Player_HorizontalMovement;
        private readonly InputAction m_Player_VerticalMovement;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Pause;
        private readonly InputAction m_Player_Resume;
        public struct PlayerActions
        {
            private @Controls m_Wrapper;
            public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @HorizontalMovement => m_Wrapper.m_Player_HorizontalMovement;
            public InputAction @VerticalMovement => m_Wrapper.m_Player_VerticalMovement;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Pause => m_Wrapper.m_Player_Pause;
            public InputAction @Resume => m_Wrapper.m_Player_Resume;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @HorizontalMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalMovement;
                    @HorizontalMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalMovement;
                    @HorizontalMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalMovement;
                    @VerticalMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                    @VerticalMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                    @VerticalMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                    @Resume.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResume;
                    @Resume.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResume;
                    @Resume.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResume;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @HorizontalMovement.started += instance.OnHorizontalMovement;
                    @HorizontalMovement.performed += instance.OnHorizontalMovement;
                    @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                    @VerticalMovement.started += instance.OnVerticalMovement;
                    @VerticalMovement.performed += instance.OnVerticalMovement;
                    @VerticalMovement.canceled += instance.OnVerticalMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @Resume.started += instance.OnResume;
                    @Resume.performed += instance.OnResume;
                    @Resume.canceled += instance.OnResume;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnHorizontalMovement(InputAction.CallbackContext context);
            void OnVerticalMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnPause(InputAction.CallbackContext context);
            void OnResume(InputAction.CallbackContext context);
        }
    }
}
