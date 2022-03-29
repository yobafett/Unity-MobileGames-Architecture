using System;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure;
using CodeBase.Services.Inputs;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed;
        
        private IInputService _inputService;
        private Camera _camera;

        private void Awake() => 
            _inputService = Game.InputService;

        private void Start() => 
            _camera = Camera.main;

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            
            if (_inputService.Axis.sqrMagnitude > Constants.EPSILON)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            
            CharacterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }
    }
}