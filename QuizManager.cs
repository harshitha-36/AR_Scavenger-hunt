using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public string hintSceneName = "HINT";
    public Color incorrectAnswerColor = new Color(1, 0, 0, 0.5f); // Semi-transparent red
    public float feedbackDuration = 1.5f; // Duration of the red flash
    public float delayBeforeHintScene = 1.5f; // Delay before loading the hint scene

    private Image redOverlay;

    private void Start()
    {
        // Find the RedOverlay panel in the scene
        redOverlay = GameObject.Find("RedOverlay").GetComponent<Image>();

        if (redOverlay != null)
        {
            redOverlay.color = Color.clear; // Initially set to transparent
        }
        else
        {
            Debug.LogError("RedOverlay panel not found in the scene.");
        }
    }

    public void CheckAnswer(GameObject selectedOption)
    {
        // Check if the selected option has the tag "true" (for correct answer)
        bool isCorrect = selectedOption.CompareTag("true");

        if (isCorrect)
        {
            // Start a coroutine to delay the scene load
            StartCoroutine(LoadHintSceneWithDelay());
        }
        else
        {
            // Show red feedback if the answer is incorrect
            StartCoroutine(ShowIncorrectFeedback());
        }
    }

    private IEnumerator LoadHintSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeHintScene);
        SceneManager.LoadScene(hintSceneName);
    }

    private IEnumerator ShowIncorrectFeedback()
    {
        if (redOverlay != null)
        {
            redOverlay.color = incorrectAnswerColor; // Set the color to semi-transparent red
            yield return new WaitForSeconds(feedbackDuration);
            redOverlay.color = Color.clear; // Reset to transparent
        }
    }
}