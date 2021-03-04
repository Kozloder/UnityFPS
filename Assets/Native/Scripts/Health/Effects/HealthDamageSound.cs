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
    public class HealthDamageSound : MonoBehaviour
    {
        [SerializeField]
        private HealthSystem health;
        [SerializeField]
        private AudioSource audioSource;

        public void OnEnable()
        {
            health.OnDamage += Play;
        }
        public void OnDisable()
        {
            health.OnDamage -= Play;
        }
        private void Play(float damage)
        {
            audioSource.Play();
        }
    }
}