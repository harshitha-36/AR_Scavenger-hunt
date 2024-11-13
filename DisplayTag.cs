using TMPro;
using UnityEngine;

public class DisplayTag : MonoBehaviour
{
    public TextMeshProUGUI tagText; // Assign this in the Inspector

    private void Start()
    {
        // Display the integer tag or 0 if no tag is set
        tagText.text = TagStorage.CurrentTag.HasValue ? TagStorage.CurrentTag.Value.ToString() : "0";
    }
}
