using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Required for IEnumerator

public class final : MonoBehaviour
{
    public string nextSceneName;

    private void OnMouseDown()
    {
        // Attempt to parse the tag of the clicked object as an integer
        if (int.TryParse(gameObject.tag, out int parsedTag))
        {
            // Save the integer tag if valid
            TagStorage.CurrentTag = parsedTag;
        }

        // Wait for 5 seconds before transitioning to the next scene
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}

