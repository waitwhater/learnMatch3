using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
//using VContainer;

namespace Assets.Scripts.Input
{
    internal class InputReader : IDisposable
    {
        public event Action Click;
        private Inputs _inputs;
        private InputAction _positionAction;
        private InputAction _fireAction;
        //private IObjectResolver _objectResolver;

        private bool _isFire;

        public InputReader(/*Inputs inputs, InputAction positionAction, InputAction fireAction, IObjectResolver objectResolver*/)
        {
            _inputs = new Inputs();
            _inputs.Player.Fire.performed += OnClick;
        }

        public void Dispose() => _inputs.Player.Fire.performed -= OnClick;


        public void EnableInputs(bool value)
        {
            if(value)
                _inputs.Enable();
            else
                _inputs.Disable();
        }

        private void OnClick(InputAction.CallbackContext obj)
        {
            Click?.Invoke();
        }

        public Vector2 Position()
        {
            return _inputs.Player.Select.ReadValue<Vector2>();
        }

    }
}
