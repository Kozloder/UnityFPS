using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nightmare
{
    public class LevelManager : MonoBehaviour
    {
        public string[] levels;

        private int currentLevel = 0;
        private Scene currentScene;
        private Vector3 playerRespawn;

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        void Start()
        {
            SceneManager.LoadSceneAsync(levels[0], LoadSceneMode.Additive);
        }

        public void AdvanceLevel()
        {
            LoadLevel(currentLevel + 1);
        }

        public void LoadInitialLevel()
        {
            LoadLevel(0);
        }

        private void LoadLevel(int level)
        {
            currentLevel = level;

            //Load next level in background
            string loadingScene = levels[level % levels.Length];
            SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (mode != LoadSceneMode.Additive)
                return;

            SceneManager.SetActiveScene(scene);

            DisableOldScene();

            currentScene = scene;
        }

        private void DisableOldScene()
        {
            if (currentScene.IsValid())
            {
                // Disable old scene.
                GameObject[] oldSceneObjects = currentScene.GetRootGameObjects();
                for (int i = 0; i < oldSceneObjects.Length; i++)
                {
                    oldSceneObjects[i].SetActive(false);
                }

                // Unload it.
                SceneManager.UnloadSceneAsync(currentScene);
            }
        }

        void OnSceneUnloaded(Scene scene)
        {

        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
    }
}