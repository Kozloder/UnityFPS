using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst;
using UnityEngine;

namespace Nightmare
{
    [BurstCompile]
    public class RangeBallisticsEffect : MonoBehaviour
    {
        [SerializeField]
        private RangeWeapon weapon;
        [SerializeField]
        private LineRenderer lineRenderer;

        [SerializeField]
        private float renderTime;
        private float currentRenderTime;

        public void Start()
        {
            enabled = false;
        }
        public void OnEnable()
        {
            weapon.onRangeShootEvent += RenderLine;
        }
        public void OnDisable()
        {
            weapon.onRangeShootEvent -= RenderLine;
        }
        private void RenderLine(Vector3 startPosition, Vector3 endPosition)
        {
            enabled = true;
            lineRenderer.SetPositions(new Vector3[]{ startPosition, endPosition});
            currentRenderTime = renderTime;
        }

        public void FixedUpdate()
        {
            if (currentRenderTime <= 0) 
            {
                enabled = false;
            }

            currentRenderTime -= Time.deltaTime;
        }
    }
}