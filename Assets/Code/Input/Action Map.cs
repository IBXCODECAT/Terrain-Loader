//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Code/Input/Action Map.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PlayerInput
{
    public partial class @ActionMap: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ActionMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Action Map"",
    ""maps"": [
        {
            ""name"": ""BuildMode"",
            ""id"": ""161fdda1-58bc-4eea-96a3-fb9bba333c52"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""69e6ed64-08cc-42d3-b345-2753bc32aa4d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookVerticalOffset"",
                    ""type"": ""Value"",
                    ""id"": ""d12441b7-2645-4074-8ea1-5c9c6ecb1e86"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a08e7fb2-1f78-4b13-94fe-cd55548d1dc4"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c32f68b4-f4ce-4340-b108-a4ca8b969671"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Middle Mouse Look"",
                    ""id"": ""94f63b67-12d8-4396-9903-917473192825"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(y=4)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7a06b270-f309-4df5-9b35-c3ebedfd2538"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""cf843fd5-7391-42d6-a021-eac3ca8de821"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6514fd04-5058-4861-bbd0-a302ceb2b5e7"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,InvertVector2(invertX=false),ScaleVector2(y=300)"",
                    ""groups"": """",
                    ""action"": ""LookVerticalOffset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // BuildMode
            m_BuildMode = asset.FindActionMap("BuildMode", throwIfNotFound: true);
            m_BuildMode_Look = m_BuildMode.FindAction("Look", throwIfNotFound: true);
            m_BuildMode_LookVerticalOffset = m_BuildMode.FindAction("LookVerticalOffset", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // BuildMode
        private readonly InputActionMap m_BuildMode;
        private List<IBuildModeActions> m_BuildModeActionsCallbackInterfaces = new List<IBuildModeActions>();
        private readonly InputAction m_BuildMode_Look;
        private readonly InputAction m_BuildMode_LookVerticalOffset;
        public struct BuildModeActions
        {
            private @ActionMap m_Wrapper;
            public BuildModeActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_BuildMode_Look;
            public InputAction @LookVerticalOffset => m_Wrapper.m_BuildMode_LookVerticalOffset;
            public InputActionMap Get() { return m_Wrapper.m_BuildMode; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BuildModeActions set) { return set.Get(); }
            public void AddCallbacks(IBuildModeActions instance)
            {
                if (instance == null || m_Wrapper.m_BuildModeActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_BuildModeActionsCallbackInterfaces.Add(instance);
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @LookVerticalOffset.started += instance.OnLookVerticalOffset;
                @LookVerticalOffset.performed += instance.OnLookVerticalOffset;
                @LookVerticalOffset.canceled += instance.OnLookVerticalOffset;
            }

            private void UnregisterCallbacks(IBuildModeActions instance)
            {
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @LookVerticalOffset.started -= instance.OnLookVerticalOffset;
                @LookVerticalOffset.performed -= instance.OnLookVerticalOffset;
                @LookVerticalOffset.canceled -= instance.OnLookVerticalOffset;
            }

            public void RemoveCallbacks(IBuildModeActions instance)
            {
                if (m_Wrapper.m_BuildModeActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IBuildModeActions instance)
            {
                foreach (var item in m_Wrapper.m_BuildModeActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_BuildModeActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public BuildModeActions @BuildMode => new BuildModeActions(this);
        public interface IBuildModeActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnLookVerticalOffset(InputAction.CallbackContext context);
        }
    }
}