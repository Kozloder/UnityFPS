using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    public abstract class VisionSystem : MonoBehaviour
    {
        public abstract bool See(Transform _transform);
    }
}