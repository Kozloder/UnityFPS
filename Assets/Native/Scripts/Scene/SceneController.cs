using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Nightmare
{
    [CreateAssetMenu (menuName = "Game/SceneController")]
    public class SceneController : ScriptableObject
    {
        public static void StopScene(GameObject sender) 
        {
            var scene = SceneManager.GetActiveScene();
            var roots = scene.GetRootGameObjects();

            for (int i = 0; i < roots.Length; i++) 
            {
                var root = roots[i];

                if (root != sender)
                    root.SetActive(false);
            }
        }

        public static void PlayScene(GameObject sender)
        {
            var scene = SceneManager.GetActiveScene();
            var roots = scene.GetRootGameObjects();

            for (int i = 0; i < roots.Length; i++)
            {
                var root = roots[i];

                if (root != sender)
                    root.SetActive(true);
            }
        }
    }
}