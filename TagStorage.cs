// public static class TagStorage
// {
//     private static int? currentTag;

//     // Static property to hold the current integer tag
//     public static int? CurrentTag
//     {
//         get => currentTag;
//         set
//         {
//             // Check if the new value is an integer; if so, store it
//             if (value is int)
//             {
//                 currentTag = value;
//             }
            
//         }
//     }
// }

public static class TagStorage
{
    private static int? currentTag = 0; // Start with tag 0

    // Static property to hold the current integer tag
    public static int? CurrentTag
    {
        get => currentTag;
        set
        {
            // Check if the new value is an integer; if so, store it
            if (value is int && value >= 0 && value <= 7) // Ensure tag is between 0 and 7
            {
                currentTag = value;
            }
        }
    }
}
