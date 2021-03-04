using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation loadSync;
    private Coroutine loadCoroutine;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadAsAsync(string sceneName, bool startOnLoad)
    {
        loadCoroutine = StartCoroutine(AsyncLoad(sceneName, startOnLoad));
    }
    public void ActivateScene()
    {
        var indexCScene = SceneManager.GetActiveScene().buildIndex;
        var _loadSync = SceneManager.UnloadSceneAsync(indexCScene);
        loadSync.allowSceneActivation = true;
        loadSync = _loadSync;
    }

    private IEnumerator AsyncLoad(string name, bool startOnLoad)
    {
        loadSync = SceneManager.LoadSceneAsync(name);
        loadSync.allowSceneActivation = startOnLoad;
        yield return loadSync;
    }
}