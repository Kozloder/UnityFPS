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
    public class PlayerJumpSystem : MonoBehaviour
    {
        [SerializeField]
        private JumpSystem jumpSystem;

        [SerializeField]
        private ButtonListener onButtonListener;

        public void OnEnable()
        {
            onButtonListener.OnClick += jumpSystem.Jump;
        }
        public void OnDisable()
        {
            onButtonListener.OnClick -= jumpSystem.Jump;
        }
    }
}