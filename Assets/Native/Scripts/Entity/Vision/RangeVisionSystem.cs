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
    public class RangeVisionSystem : VisionSystem
    {
        [SerializeField]
        private float visionRange;

        public override bool See(Transform go)
        {
            var position = transform.position;
            var goPosition = go.position;
            var distance = position - goPosition;
            var distanceMagnitude = distance.magnitude;

            return distanceMagnitude <= visionRange;
        }
    }
}