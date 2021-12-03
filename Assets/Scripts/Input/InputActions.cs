// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""id"": ""c5c088e0-5faf-458f-82fc-3111512119c9"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""PassThrough"",
                    ""id"": ""24c842b2-b88d-4999-bbfa-a2286ece76ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d66f41bd-2eb9-47d9-87ae-91cb9294dccb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9a414b8b-2193-404c-9e72-c60aae8fd545"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterWarpPipe"",
                    ""type"": ""Button"",
                    ""id"": ""24835fe3-dfc7-4274-8ba3-fb6eadebecf6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""d584cf5a-dd20-499d-8d5f-cbc7d370092a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0707ceed-8c18-4816-be6e-41f9c68af168"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07592104-be70-4176-b28c-af152677af50"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f809c9c3-0417-49e5-b74f-8571e5555db1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87073c5c-adec-4adc-bc8c-6d3e45c154ea"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""EnterWarpPipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf98a3f5-735c-477d-bd1f-3716e157b39f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // KeyboardAndMouse
        m_KeyboardAndMouse = asset.FindActionMap("KeyboardAndMouse", throwIfNotFound: true);
        m_KeyboardAndMouse_Left = m_KeyboardAndMouse.FindAction("Left", throwIfNotFound: true);
        m_KeyboardAndMouse_Right = m_KeyboardAndMouse.FindAction("Right", throwIfNotFound: true);
        m_KeyboardAndMouse_Jump = m_KeyboardAndMouse.FindAction("Jump", throwIfNotFound: true);
        m_KeyboardAndMouse_EnterWarpPipe = m_KeyboardAndMouse.FindAction("EnterWarpPipe", throwIfNotFound: true);
        m_KeyboardAndMouse_Enter = m_KeyboardAndMouse.FindAction("Enter", throwIfNotFound: true);
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

    // KeyboardAndMouse
    private readonly InputActionMap m_KeyboardAndMouse;
    private IKeyboardAndMouseActions m_KeyboardAndMouseActionsCallbackInterface;
    private readonly InputAction m_KeyboardAndMouse_Left;
    private readonly InputAction m_KeyboardAndMouse_Right;
    private readonly InputAction m_KeyboardAndMouse_Jump;
    private readonly InputAction m_KeyboardAndMouse_EnterWarpPipe;
    private readonly InputAction m_KeyboardAndMouse_Enter;
    public struct KeyboardAndMouseActions
    {
        private @InputActions m_Wrapper;
        public KeyboardAndMouseActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_KeyboardAndMouse_Left;
        public InputAction @Right => m_Wrapper.m_KeyboardAndMouse_Right;
        public InputAction @Jump => m_Wrapper.m_KeyboardAndMouse_Jump;
        public InputAction @EnterWarpPipe => m_Wrapper.m_KeyboardAndMouse_EnterWarpPipe;
        public InputAction @Enter => m_Wrapper.m_KeyboardAndMouse_Enter;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardAndMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnRight;
                @Jump.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnJump;
                @EnterWarpPipe.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnEnterWarpPipe;
                @EnterWarpPipe.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnEnterWarpPipe;
                @EnterWarpPipe.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnEnterWarpPipe;
                @Enter.started -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @EnterWarpPipe.started += instance.OnEnterWarpPipe;
                @EnterWarpPipe.performed += instance.OnEnterWarpPipe;
                @EnterWarpPipe.canceled += instance.OnEnterWarpPipe;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public KeyboardAndMouseActions @KeyboardAndMouse => new KeyboardAndMouseActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IKeyboardAndMouseActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnEnterWarpPipe(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}
