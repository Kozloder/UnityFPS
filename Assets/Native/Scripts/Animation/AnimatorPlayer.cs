using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class AnimatorPlayer : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private string animationBool;

        [SerializeField]
        private bool onEnable;

        public void OnEnable()
        {
            if (onEnable)
                Play();
        }
        public void Play()
        {
            if (audioSource != null)
                audioSource.Play();

            animator.SetBool(animationBool, true);
        }
    }
}