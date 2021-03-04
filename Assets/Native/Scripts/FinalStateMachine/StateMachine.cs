using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;
using Unity.Burst;

namespace Nightmare
{
    /*
     * Destroys' root object when no nextState is set
     */

    [BurstCompile]
    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private GameObject nextState;
        [SerializeField]
        private bool Active;
        
        private void Start()
        {
            gameObject.SetActive(Active);
        }
        public void Next()
        {
            if (gameObject.activeSelf)
            {
                if (nextState != null)
                {
                    gameObject.SetActive(false);
                    nextState?.SetActive(true);
                }
            }
        }
    }
}