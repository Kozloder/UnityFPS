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
    public class HitEffect : MonoBehaviour
    {
        [SerializeField]
        private RangeWeapon weapon;
        [SerializeField]
        private ParticleSystem particles;

        public void OnEnable()
        {
            weapon.onRangeShootEvent += RenderParticles;
        }
        public void OnDisable()
        {
            weapon.onRangeShootEvent -= RenderParticles;
        }

        private void RenderParticles(Vector3 start, Vector3 end)
        {
            particles.Emit(new ParticleSystem.EmitParams() 
            { 
                position = end, 
                applyShapeToPosition = true 
            },
            particles.particleCount);
        }
    }
}