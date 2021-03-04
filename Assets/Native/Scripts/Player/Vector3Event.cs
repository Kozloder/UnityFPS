using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu (menuName = "Game/Vector3Event")]
    public class Vector3Event : ScriptableObject
    {
        public event Action<Vector3> onVector3Event;

        public void Invoke(Vector3 vect3) 
        {
            onVector3Event(vect3);
        }
    }
}