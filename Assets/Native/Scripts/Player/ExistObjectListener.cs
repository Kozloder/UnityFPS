using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu(menuName = "Game/ExistObjectListener")]
    public class ExistObjectListener : ScriptableObject
    {
        private GameObject go;

        private event Action<GameObject> _onAddEvent = (arg) => { };
        public event Action<GameObject> onExistEvent
        {
            add
            {
                _onAddEvent += value;
                if (go != null)
                    value(go);
            }
            remove { _onAddEvent -= value; }
        }

        private event Action<GameObject> _onRemoveEvent = (arg) => {};
        public event Action<GameObject> onMissEvent 
        { 
            add 
            {
                _onRemoveEvent += value;
                if (go == null)
                    value(go);
            } 
            remove { _onRemoveEvent -= value; } 
        }

        public void Added(GameObject go) 
        {
            if (this.go == null)
            {
                this.go = go;
                _onAddEvent(go);
            }
        }
        public void Removed(GameObject go) 
        {
            if(go == this.go) 
            {
                _onRemoveEvent(go);
                this.go = null;
            }
        }
    }
}