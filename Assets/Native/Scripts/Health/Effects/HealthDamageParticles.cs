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
    public class HealthDamageParticles : MonoBehaviour
    {
        [SerializeField]
        private HealthSystem health;
        [SerializeField]
        private ParticleSystem particles;

        public void OnEnable()
        {
            health.OnDamage += Hit;
        }
        public void OnDisable()
        {
            health.OnDamage -= Hit;
        }
        private void Hit(float damage) 
        {
            particles.Play();
        }
    }
}