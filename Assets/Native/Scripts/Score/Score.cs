using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu(menuName = "Game/ScoreData")]
    public class Score : ScriptableObject
    {
        public int score;
    }
}