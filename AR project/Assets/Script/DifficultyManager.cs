using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static int selectedDifficulty; // Static variable to store the selected difficulty level

    public void SetDifficulty(int difficultyLevel)
    {
        selectedDifficulty = difficultyLevel; // Store the selected difficulty level
    }
}
