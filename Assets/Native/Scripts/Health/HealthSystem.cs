using UnityEngine;
using System;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField]
        private int currentHealth = 100;

        [SerializeField]
        private bool godMode = false;

        [SerializeField]
        private StateMachine nextState;

        public event Action<float> OnDamage = (arg) => { };

        public void Damage(int amount)
        {
            if (!godMode)
            {
                currentHealth -= amount;

                if (currentHealth <= 0)
                    nextState.Next();
                else
                    OnDamage(currentHealth);
            }
        }
    }
}