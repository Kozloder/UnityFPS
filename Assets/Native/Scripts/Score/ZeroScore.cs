using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    public class ZeroScore : MonoBehaviour
    {
        [SerializeField]
        private Score score;
        public void Awake()
        {
            score.score = 0;
        }
    }
}