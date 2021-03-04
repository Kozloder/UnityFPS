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
    public class RapidyFireWeapon : Weapon
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private float rapidy;

        private float lastTime;
        public override void Shoot(HealthSystem shootedHealth)
        {
            var dTime = Time.time - lastTime;
            
            if (dTime >= rapidy)
            {
                weapon.Shoot(shootedHealth);
                lastTime = Time.time;
            }
        }
    }
}