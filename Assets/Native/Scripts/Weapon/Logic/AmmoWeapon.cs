using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst;
using UnityEngine;

namespace Nightmare
{
    [BurstCompile]
    public class AmmoWeapon : Weapon
    {
        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private int ammo;
        public int Ammo { get => ammo; set => ammo = value; }

        [SerializeField]
        private int maxAmmo;
        [SerializeField]
        private bool infinite;

        public override void Shoot(HealthSystem shootedHealth)
        {
            if (infinite)
                _Shoot(shootedHealth);
            else
            {
                ammo = (--ammo) < 0 ? 0 : ammo;

                if (ammo != 0)
                {
                    _Shoot(shootedHealth);
                }
            }
        }
        
        private void _Shoot(HealthSystem shootedHealth) 
        {
            InvokeShootEvent();
            weapon.Shoot(shootedHealth);
        }
    }
}