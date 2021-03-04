using UnityEngine;
using UnityEngine.Events;
using System.Text;
using System;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class DamageWeapon : Weapon
    {
        [SerializeField]
        private int damage = 20;

        public override void Shoot(HealthSystem shootedHealth)
        {
            if (shootedHealth != null)
            {
                shootedHealth.Damage(damage);
                InvokeShootEvent();
            }
        }
    }
}