using UnityEngine;
using Unity.Burst;

namespace Nightmare
{
    [BurstCompile]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPoints;
        [SerializeField]
        private GameObject enemy;

        [SerializeField]
        private float spawnTime = 3f;
        private float currentSpawnTime;

        public void Start()
        {
            currentSpawnTime = spawnTime;
        }

        public void FixedUpdate()
        {
            if (currentSpawnTime <= 0) 
            {
                Spawn();
                currentSpawnTime = spawnTime;
            }

            currentSpawnTime -= Time.deltaTime;
        }

        private void Spawn()
        {
            var point = RandPoint();            
            var _enemy = Instantiate (enemy, point.position, point.rotation);
        }

        private Transform RandPoint() 
        {
            var randIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            var randSpawnPoint = spawnPoints[randIndex];

            return randSpawnPoint;
        }
    }
}