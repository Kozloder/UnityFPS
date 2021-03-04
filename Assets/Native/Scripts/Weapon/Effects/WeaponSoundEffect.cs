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
    public class WeaponSoundEffect : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private AudioSource sound;

        public void OnEnable()
        {
            weapon.OnShootEvent += sound.Play;
        }
        public void OnDisable()
        {
            weapon.OnShootEvent -= sound.Play;
        }
    }
}