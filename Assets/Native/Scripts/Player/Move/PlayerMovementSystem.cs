using Unity.Burst;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Nightmare
{
    [BurstCompile]
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField]
        private JoystickListener joystick;

        [SerializeField]
        private CharacterController characterController;
        [SerializeField]
        private AnimatorPlayer animatorPlayer;

        private void OnEnable()
        {
            joystick.OnMove += Move;
        }
        private void OnDisable()
        {
            joystick.OnMove -= Move;
        }
        private void Move(Vector2 vect2)
        {
            animatorPlayer.Play();
            var dest = new Vector3(vect2.x,
                       characterController.transform.position.y,
                       vect2.y);
            characterController.Move(dest);
        }
    }
}