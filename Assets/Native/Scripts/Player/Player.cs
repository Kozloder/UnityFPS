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
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private ExistObjectListener playerExist;

        public void OnEnable()
        {
            playerExist.Added(gameObject);
        }
        public void OnDisable()
        {
            playerExist.Removed(gameObject);
        }
    }
}