using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Button submitButton;
    public TMP_InputField inputField;
    public TextMeshProUGUI playerNameDisplay;

    private string[] randomNames = { "Jeff", "Blop", "Ronaldo", "Chris", "Angela", "Arthur", "Katara", "Luffy", "Zoro", "Usopp" };

    private void Start()
    {
        // Load or initialize the username
        if (!PlayerPrefs.HasKey("Username"))
        {
            string randomName = randomNames[Random.Range(0, randomNames.Length)];
            PlayerPrefs.SetString("Username", randomName);
        }

        // Display the stored username in both the input field and the display text
        string storedUsername = PlayerPrefs.GetString("Username");
        inputField.text = storedUsername;
        playerNameDisplay.text = storedUsername;

        // Attach the SaveName method to the submit button
        submitButton.onClick.AddListener(SaveName);
    }

    private void SaveName()
    {
        if (!string.IsNullOrEmpty(inputField.text) && inputField.text.Length <= 17)
        {
            string newUsername = inputField.text;
            
            // Save the new username in PlayerPrefs
            PlayerPrefs.SetString("Username", newUsername);
            playerNameDisplay.text = newUsername;

            // Retrieve the current tag value from TagStorage
            int score = TagStorage.CurrentTag.HasValue ? TagStorage.CurrentTag.Value : 0;

            // Update the leaderboard with the new username and tag value
            LeaderboardController leaderboardController = FindObjectOfType<LeaderboardController>();
            if (leaderboardController != null)
            {
                leaderboardController.SetEntry(newUsername, score);
            }
        }
        else
        {
            inputField.text = "Invalid name!";
        }
    }
}
