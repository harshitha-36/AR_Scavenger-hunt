using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadSceneOnClick : MonoBehaviour
{
    // The name of the scene you want to load
    public string sceneName;

    // Method to call on button click
    public void LoadTargetScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            StartCoroutine(LoadWithDelay());
        }
        else
        {
            Debug.LogWarning("Scene name not set in Inspector.");
        }
    }

    private IEnumerator LoadWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}