using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class ThrownWeapon : Weapon
    {
        [SerializeField]
        private GameObject thrown;
        [SerializeField]
        private Transform startThrownPoint;
        [SerializeField]
        private Transform endThrownPoin;
        [SerializeField]
        private float thrownForce;

        public override void Shoot(HealthSystem shootedHealth)
        {
            var grenade = Instantiate(thrown, startThrownPoint.position, new Quaternion(), null);
            
            if (grenade.TryGetComponent<Rigidbody>(out var rb))
            {
                var thrownVect = (endThrownPoin.position - startThrownPoint.position).normalized;
                rb.AddForce(thrownVect * thrownForce, ForceMode.Impulse);
            }
        }
    }
}