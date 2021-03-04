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
    public class RangeWeapon : Weapon
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private float onRange;

        public event Action<Vector3, Vector3> onRangeShootEvent = (arg1, arg2) => { };

        public override void Shoot(HealthSystem shootedHealth)
        {
            if (shootedHealth == null)
            {
                var startHitPoint = transform.position;
                var ray = new Ray(startHitPoint, transform.forward);

                if (Physics.Raycast(ray, out var result, onRange))
                {
                    var collider = result.collider;

                    if (collider.TryGetComponent<HealthSystem>(out var health))
                    {
                        _Shoot(health, startHitPoint, result.point);
                    }
                }

            }
            else _Shoot(shootedHealth,transform.position, shootedHealth.transform.position);
        }
        private void _Shoot(HealthSystem shootedHealth, Vector3 startRayVect, Vector3 endRayVect) 
        {
            InvokeShootEvent();
            onRangeShootEvent(startRayVect, endRayVect);
            weapon.Shoot(shootedHealth);
        }
    }
}
