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
    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private float radius;
        [SerializeField]
        private int damage;

        [SerializeField]
        private float inTime;
        private float currentTime;

        public void OnEnable()
        {
            currentTime = inTime;
        }
        public void FixedUpdate()
        {
            if (currentTime <= 0) 
            {
                Explode();
            }

            currentTime -= Time.deltaTime;
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<HealthSystem>(out var health)) 
            {
                Explode();
            }
        }
        public void Explode()
        {
            var collided = Physics.OverlapSphere(transform.position,radius);

            for (int i = 0; i < collided.Length; i++) 
            {
                var collider = collided[i];
                
                if (collider.TryGetComponent<HealthSystem>(out var health)) 
                {
                    health.Damage(damage);
                }
            }

            enabled = false;
        }
    }
}