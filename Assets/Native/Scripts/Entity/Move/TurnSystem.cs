using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Nightmare
{
    [BurstCompile]
    [RequireComponent(typeof(Rigidbody))]
    public class TurnSystem : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidBody;

        public void Turn(Vector2 direction, float force)
        {
            Vector3 turnDirection = new Vector3(direction.x,0,direction.y);
            Vector3 lookQuaternion = (transform.position + turnDirection) - transform.position;
            
            lookQuaternion.y = 0f;

            Quaternion rotationQuaternion = Quaternion.LookRotation(lookQuaternion);

            rigidBody.MoveRotation(rotationQuaternion);
        }
    }
}