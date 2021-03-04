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
    public class WeaponButtonRegistrator : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private ButtonListener onShootButton;

        public void OnEnable()
        {
            onShootButton.OnClick += Shoot;
        }
        public void OnDisable()
        {
            onShootButton.OnClick -= Shoot;
        }

        private void Shoot()
        {
            weapon.Shoot(null);
        }
    }
}
