using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private WeaponType weaponType;
        public WeaponType Type { get => weaponType; }

        public event Action OnShootEvent = () => { };

        protected void InvokeShootEvent() 
        {
            OnShootEvent();
        }
        public abstract void Shoot(HealthSystem shootedHealth);
    }
}