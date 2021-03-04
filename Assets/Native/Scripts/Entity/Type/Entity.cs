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
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private EntityType type;
        public EntityType Type { get => type; }
    }
}