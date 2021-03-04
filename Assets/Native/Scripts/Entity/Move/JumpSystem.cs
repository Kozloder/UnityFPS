using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

namespace Nightmare 
{
    [BurstCompile]
    public class JumpSystem : MonoBehaviour
    {
        [SerializeField]
        private CharacterController character;

        [SerializeField]
        private Animator animator;
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private float force = 10f;

        public void Jump()
        {
            if (character.isGrounded)
            {
                var direct = new Vector3(0, force, 0);
                character.Move(direct);
                animator.SetBool("IsJump", true);
                audioSource.Play();
            }
        }
    }
}