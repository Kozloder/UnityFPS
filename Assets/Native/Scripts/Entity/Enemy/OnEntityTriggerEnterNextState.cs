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
    public class OnEntityTriggerEnterNextState : MonoBehaviour
    {
        [SerializeField]
        private StateMachine stateMachine;
        [SerializeField]
        private EntityType entityType;

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Entity>(out var entity))
            {
                if (entity.Type == entityType) 
                {
                    stateMachine.Next();
                }
            }
        }
    }
}