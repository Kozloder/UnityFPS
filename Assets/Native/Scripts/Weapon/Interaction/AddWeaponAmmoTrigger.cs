using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    public class AddWeaponAmmoTrigger : MonoBehaviour
    {
        [SerializeField]
        private int ammo;
        [SerializeField]
        private WeaponType weaponType;
        [SerializeField]
        private StateMachine addedState;

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<AmmoWeapon>(out var ammo)) 
            {
                if (ammo.Type == weaponType)
                {
                    ammo.Ammo = this.ammo;
                    addedState.Next();
                }
            }
        }
    }
}