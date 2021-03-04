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
    public class DestroyAllHierarchy : MonoBehaviour
    {
        [SerializeField]
        private float inTime;

        public void FixedUpdate()
        {
            if (inTime <= 0)
                Destroy(transform.root);

            inTime -= Time.deltaTime;
        }
    }
}