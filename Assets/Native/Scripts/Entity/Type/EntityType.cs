using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu (menuName = "Game/EntityType")]
    public class EntityType : ScriptableObject
    {
        [SerializeField]
        private string name;

        public static bool operator==(EntityType arg1, EntityType arg2) 
        {
            return arg1.name == arg2.name;
        }
        public static bool operator!=(EntityType arg1, EntityType arg2) 
        {
            return arg1.name != arg2.name;
        }
    }
}