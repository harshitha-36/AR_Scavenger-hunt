using TMPro;
using UnityEngine;

public class HintDisplay : MonoBehaviour
{
    public TextMeshProUGUI hintTextBox;

    private void Start()
    {
        // Display the hint based on the CurrentTag
        UpdateHintDisplay();
    }

    private void UpdateHintDisplay()
    {
        if (TagStorage.CurrentTag.HasValue)
        {
            int tagValue = TagStorage.CurrentTag.Value;
            
            // Determine the hint based on the integer tag
            switch (tagValue)
            {
                case 1:
                    hintTextBox.text = "Seek the stairs where seats are few, and only a small group will do. A closed door guards this quiet scene, near the buzz yet unseen.";
                    break;
                case 2:
                    hintTextBox.text = "It’s where the magic happens for your hair—a place of combs, curls, and care. Can you find the spot where styles are made?";
                    break;
                case 3:
                    hintTextBox.text = "Look up above the pizza slice, near the gym where you pay the price. A famous date spot, but bring your wallet!";
                    break;
                case 4:
                    hintTextBox.text = "It’s a place where spices meet, from North to South with every treat. A mess that’s colorful, tempting to see, where can it be?";
                    break;
                case 5:
                    hintTextBox.text = "Where the ball flies and the players run, the game of hoops is always fun. Dribble and shoot, can you guess? The court where the players impress?";
                    break;
                case 6:
                    hintTextBox.text = "Where the ball bounces and paddles swing, three chairs wait for those who bring a moment’s pause. ";
                    break;
                // Add additional cases as needed
                default:
                    hintTextBox.text = "Head to the place where four tastes collide and friends gather side by side. It’s where you’ll find tables set for a chat-filled meal.";
                    break;
            }
        }
        else
        {
            hintTextBox.text = "Head to the place where Time fights for justice";
        }
    }
}
