using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Nightmare
{
    public class ScoreView : MonoBehaviour 
    {
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private Score score;

        public void FixedUpdate()
        {
            text.text = score.score.ToString();
        }
    }
}