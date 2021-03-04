using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu (menuName = "Game/WeaponType")]
    public class WeaponType : ScriptableObject
    {
        [SerializeField]
        private string typeName;

        public static bool operator==(WeaponType arg1, WeaponType arg2) 
        {
            return arg1.typeName == arg2.typeName;
        }
        public static bool operator!=(WeaponType arg1, WeaponType arg2) 
        {
            return arg1.typeName != arg2.typeName;
        }
    }
}