using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderboardController : MonoBehaviour
{
    public List<TextMeshProUGUI> usernameTexts;
    public List<TextMeshProUGUI> scoreTexts;

    private string publicKey = "ede82e4d0767433f37e3d0c1a74763226b259c9d56abf662a16fb176ef47abaa";

    private void Start()
    {
        LoadEntries();
    }

    public void LoadEntries()
    {
        // Fetch entries for AR_Treasurehunt leaderboard with the given public key
        Leaderboards.AR_Treasurehunt.GetEntries(entries =>
        {
            // Clear existing entries
            foreach (TextMeshProUGUI nameText in usernameTexts)
            {
                nameText.text = "";
            }
            foreach (TextMeshProUGUI scoreText in scoreTexts)
            {
                scoreText.text = "";
            }

            int length = Mathf.Min(usernameTexts.Count, entries.Length);

            // Populate leaderboard entries
            for (int i = 0; i < length; i++)
            {
                usernameTexts[i].text = entries[i].Username;
                scoreTexts[i].text = entries[i].Score.ToString();
            }
        });
    }

    public void SetEntry(string username, int score)
    {
        // Upload new entry with username and score
        Leaderboards.AR_Treasurehunt.UploadNewEntry(username, score, isSuccessful =>
        {
            if (isSuccessful)
            {
                // Refresh entries after a successful upload
                LoadEntries();

                // Update score based on tag, if applicable
                foreach (TextMeshProUGUI nameText in usernameTexts)
                {
                    if (nameText.text == username)
                    {
                        int index = usernameTexts.IndexOf(nameText);
                        if (index >= 0 && index < scoreTexts.Count)
                        {
                            // Use tag as score if available, otherwise display score as "0"
                            scoreTexts[index].text = TagStorage.CurrentTag.HasValue 
                                ? TagStorage.CurrentTag.Value.ToString() 
                                : score.ToString();
                        }
                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("Failed to upload leaderboard entry. Please try again.");
            }
        });
    }
}
