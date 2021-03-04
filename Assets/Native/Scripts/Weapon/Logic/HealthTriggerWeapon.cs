using UnityEngine;
using System.Collections;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class HealthTriggerWeapon : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private EntityType attackOnEntity;

        private HealthSystem entityHealth;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Entity>(out var ent)) 
            {
                if (ent.Type == attackOnEntity) 
                {
                    if (other.TryGetComponent<HealthSystem>(out var health))
                    {
                        entityHealth = health;
                        weapon.Shoot(health);
                    }
                }
            }
        }

        private void OnTriggerStay (Collider other)
        {
            if (entityHealth != null)
                if(other.gameObject == entityHealth.gameObject)
                {
                    weapon.Shoot(entityHealth);
                }
        }
    }
}