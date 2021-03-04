using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu(menuName = "Game/Input/JoystickListener")]
    public class JoystickListener : ScriptableObject
    {
        public event Action<Vector2> OnMove = (arg) => { };

        public void Invoke(Vector2 direction) 
        {
            OnMove(direction);
        }
    }
}