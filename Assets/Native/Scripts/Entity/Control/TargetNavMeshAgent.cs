using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;
using Unity.Burst;
using UnityEngine;

namespace Nightmare
{
    [BurstCompile]
    public class TargetNavMeshAgent : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent navAgent;

        private Transform target;

        public void FixedUpdate()
        {
            if (target != null) 
            {
                var targetPosition = target.position;
                if (navAgent.pathEndPosition != targetPosition) 
                {
                    navAgent.destination = targetPosition;
                }
            }
        }

        public Transform Target
        {
            set => target = value;
            private get => target;
        }
        public bool HasTarget() 
        {
            return navAgent.hasPath;
        }
        public void Stop()
        {
            navAgent.ResetPath();
        }
        public float Speed
        {
            get => navAgent.speed;
            set => navAgent.speed = value;
        }
    }
}