using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu(menuName = "Game/Input/ButtonListener")]
    public class ButtonListener : ScriptableObject
    {
        public event Action OnClick = () => { };

        public void Click()
        {
            OnClick();
        }
    }
}