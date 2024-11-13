// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro; // Import TextMeshPro namespace
// using System.Collections; // Required for IEnumerator

// public class ObjectButton : MonoBehaviour
// {
//     public string nextSceneName;
//     public TextMeshProUGUI hintText; // Assign your TextMeshProUGUI object here

//     private void OnMouseDown()
//     {
//         // Attempt to parse the tag of the clicked object as an integer
//         if (int.TryParse(gameObject.tag, out int parsedTag))
//         {
//             // Save the integer tag if valid
//             TagStorage.CurrentTag = parsedTag;
//         }

//         // Show the hint message
//         if (hintText != null)
//         {
//             hintText.text = "Congrats! Level cleared. Solve a problem for your next clue.";
//         }

//         // Wait for 5 seconds before transitioning to the next scene
//         StartCoroutine(WaitAndLoadScene());
//     }

//     private IEnumerator WaitAndLoadScene()
//     {
//         // Wait for 5 seconds
//         yield return new WaitForSeconds(5f);

//         // Load the next scene
//         SceneManager.LoadScene(nextSceneName);
//     }
// }



// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;
// using System.Collections;

// public class ObjectButton : MonoBehaviour
// {
//     public string nextSceneName;
//     public TextMeshProUGUI hintText;
//     public int objectTag;

//     private void Start()
//     {
//         CheckAndHideObjects();
//     }

//     private void OnMouseDown()
//     {
//         // Save the current object's tag
//         TagStorage.CurrentTag = objectTag;

//         // Show the hint message
//         hintText.text = "Congrats! Level cleared. Solve a problem for your next clue.";

//         // Wait and load the next scene
//         StartCoroutine(WaitAndLoadScene());
//     }

//     private IEnumerator WaitAndLoadScene()
//     {
//         yield return new WaitForSeconds(5f);
//         SceneManager.LoadScene(nextSceneName);
//     }

//     private void CheckAndHideObjects()
//     {
//         int? currentTag = TagStorage.CurrentTag;

//         // Hide objects based on the current tag
//         if (currentTag.HasValue)
//         {
//             // Use a switch-case to handle different tag values more efficiently
//             switch (currentTag)
//             {
//                 case 0:
//                     HideObjects(2, 7);
//                     break;
//                 case 1:
//                     HideObjects(3, 7);
//                     break;
//                 case 2:
//                     HideObjects(4, 7);
//                     break;
//                 case 3:
//                     HideObjects(5, 7);
//                     break;
//                 case 4:
//                     HideObjects(6, 7);
//                     break;
//                 case 5:
//                     HideObjects(7, 7);
//                     break;
//             }
//         }
//     }

//     private void HideObjects(int startTag, int endTag)
//     {
//         GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

//         foreach (GameObject obj in objects)
//         {
//             if (int.TryParse(obj.tag, out int tag))
//             {
//                 obj.SetActive(tag >= startTag && tag <= endTag);
//             }
//         }
//     }
// }




using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class ObjectButton : MonoBehaviour
{
    public string nextSceneName;
    public TextMeshProUGUI hintText;
    public int objectTag;

    private void Start()
    {
        // Check if the current tag is less than the object's tag
        if (TagStorage.CurrentTag + 1 < objectTag)
        {
            // Hide the object if the current tag is lower
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        // Update the current tag in TagStorage
        TagStorage.CurrentTag = objectTag;

        // Show the hint message
        hintText.text = "Congrats! Level cleared. Solve a problem for your next clue.";

        // Wait and load the next scene
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(nextSceneName);
    }
}



// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;
// using System.Collections;

// public class ObjectButton : MonoBehaviour
// {
//     public string nextSceneName;
//     public TextMeshProUGUI hintText;
//     public int objectTag;
//     public GameObject particleEffect; // Reference to the particle effect object

//     private void Start()
//     {
//         // Check if the current tag is less than the object's tag
//         if (TagStorage.CurrentTag + 1 < objectTag)
//         {
//             // Hide the object and the particle effect if the current tag is lower
//             gameObject.SetActive(false);
//             particleEffect.SetActive(false);
//         }
//     }

//     private void OnMouseDown()
//     {
//         // Update the current tag in TagStorage
//         TagStorage.CurrentTag = objectTag;

//         // Show the hint message
//         hintText.text = "Congrats! Level cleared. Solve a problem for your next clue.";

//         // Activate the particle effect
//         particleEffect.SetActive(true);

//         // Wait and load the next scene
//         StartCoroutine(WaitAndLoadScene());
//     }

//     private IEnumerator WaitAndLoadScene()
//     {
//         yield return new WaitForSeconds(5f);
//         SceneManager.LoadScene(nextSceneName);
//     }
// }