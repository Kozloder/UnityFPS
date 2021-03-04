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
    public class WanderingAISystem : MonoBehaviour
    {
        [SerializeField]
        private ExistObjectListener existObject;
        [SerializeField]
        private NavMeshAgent navAgent;
        [SerializeField]
        private AnimatorPlayer animatorPlayer;

        [SerializeField]
        private float range;
        [SerializeField]
        private float timeChangePath;
        private float currentTimeChangePath;

        public void OnEnable()
        {
            currentTimeChangePath = timeChangePath;
            existObject.onMissEvent += Activate;
            existObject.onExistEvent += Deactivate;
        }
        public void OnDisable()
        {
            existObject.onMissEvent -= Activate;
            existObject.onExistEvent -= Deactivate;
        }
        private void Activate(GameObject go) 
        {
            enabled = true;
        }
        private void Deactivate(GameObject go) 
        {
            enabled = false;
        }

        public void FixedUpdate()
        {
            if (currentTimeChangePath <= 0)
            {
                var pathTarget = GetRandToPath();
                navAgent.SetDestination(pathTarget);
                animatorPlayer.Play();
                currentTimeChangePath = timeChangePath;
            }

            currentTimeChangePath -= Time.deltaTime;
        }

        private Vector3 GetRandToPath() 
        {
            var randX = UnityEngine.Random.Range(0, range);
            var randZ = UnityEngine.Random.Range(0, range);

            return new Vector3(randX, transform.position.y, randZ);
        }
    }
}