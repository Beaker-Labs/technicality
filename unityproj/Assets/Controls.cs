//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Vehicle"",
            ""id"": ""d6b6ccd5-3604-4cf6-b3d1-4aeb86c5528a"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""2b2336e2-0c83-46ab-a22f-d2db104f6547"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""06ed12c5-c0ba-4c51-a2cf-eb3f0cf98018"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""382660b7-bb2b-4ab8-929a-e5942d84c9cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""d83d2f8d-8de7-45ac-93a4-917f3219b03c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""51430220-82ed-45d9-8e31-b857cea53bdd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""6cc943d2-3e02-4a79-8953-fe9af84217f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""295ffae5-59f5-4e80-badd-e8db3dc30344"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1890a9e-519e-43ee-a2b1-0d21fe08814b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0d71229-b4d2-4db2-b900-0ec4a6c5b844"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e836cff-103e-4d98-9f67-a75f0071d1c5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fefe777-88e9-435a-b809-36cd6dff10a5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e11c3c25-9264-49c3-a66c-39ac1af8be5b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Vehicle
        m_Vehicle = asset.FindActionMap("Vehicle", throwIfNotFound: true);
        m_Vehicle_Forward = m_Vehicle.FindAction("Forward", throwIfNotFound: true);
        m_Vehicle_Backward = m_Vehicle.FindAction("Backward", throwIfNotFound: true);
        m_Vehicle_TurnLeft = m_Vehicle.FindAction("TurnLeft", throwIfNotFound: true);
        m_Vehicle_TurnRight = m_Vehicle.FindAction("TurnRight", throwIfNotFound: true);
        m_Vehicle_Left = m_Vehicle.FindAction("Left", throwIfNotFound: true);
        m_Vehicle_Right = m_Vehicle.FindAction("Right", throwIfNotFound: true);
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

    // Vehicle
    private readonly InputActionMap m_Vehicle;
    private IVehicleActions m_VehicleActionsCallbackInterface;
    private readonly InputAction m_Vehicle_Forward;
    private readonly InputAction m_Vehicle_Backward;
    private readonly InputAction m_Vehicle_TurnLeft;
    private readonly InputAction m_Vehicle_TurnRight;
    private readonly InputAction m_Vehicle_Left;
    private readonly InputAction m_Vehicle_Right;
    public struct VehicleActions
    {
        private @Controls m_Wrapper;
        public VehicleActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Vehicle_Forward;
        public InputAction @Backward => m_Wrapper.m_Vehicle_Backward;
        public InputAction @TurnLeft => m_Wrapper.m_Vehicle_TurnLeft;
        public InputAction @TurnRight => m_Wrapper.m_Vehicle_TurnRight;
        public InputAction @Left => m_Wrapper.m_Vehicle_Left;
        public InputAction @Right => m_Wrapper.m_Vehicle_Right;
        public InputActionMap Get() { return m_Wrapper.m_Vehicle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VehicleActions set) { return set.Get(); }
        public void SetCallbacks(IVehicleActions instance)
        {
            if (m_Wrapper.m_VehicleActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnBackward;
                @TurnLeft.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnTurnLeft;
                @TurnRight.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnTurnRight;
                @TurnRight.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnTurnRight;
                @TurnRight.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnTurnRight;
                @Left.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_VehicleActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_VehicleActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_VehicleActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_VehicleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @TurnLeft.started += instance.OnTurnLeft;
                @TurnLeft.performed += instance.OnTurnLeft;
                @TurnLeft.canceled += instance.OnTurnLeft;
                @TurnRight.started += instance.OnTurnRight;
                @TurnRight.performed += instance.OnTurnRight;
                @TurnRight.canceled += instance.OnTurnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public VehicleActions @Vehicle => new VehicleActions(this);
    public interface IVehicleActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
