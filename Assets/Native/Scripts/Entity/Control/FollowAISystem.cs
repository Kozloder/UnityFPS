using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class FollowAISystem : MonoBehaviour
    {
        [SerializeField]
        private ExistObjectListener onObject;
        [SerializeField]
        private TargetNavMeshAgent targetAgent;
        [SerializeField]
        private VisionSystem visionSystem;
        [SerializeField]
        private AnimatorPlayer animatorPlayer;

        private Transform target;

        public void OnEnable()
        {
            onObject.onExistEvent += Activate;
            onObject.onMissEvent += Deactivate;
        }
        public void OnDisable()
        {
            onObject.onExistEvent -= Activate;
            onObject.onMissEvent -= Deactivate;
        }

        private void Activate(GameObject go)
        {
            target = go.transform;
            enabled = true;
        }
        private void Deactivate(GameObject go)
        {
            target = null;
            targetAgent.Stop();
            enabled = false;
        }

        public void FixedUpdate()
        {
            if (!targetAgent.HasTarget())
                    if (visionSystem.See(target))       
                    {
                        animatorPlayer.Play();
                        targetAgent.Target = target;
                    }
        }
    }
}
