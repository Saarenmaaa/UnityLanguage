using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    // This method is called when the Start button is pressed
    public void StartGame()
    {
        // Load the game scene by its name (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        // Load the game scene by its name (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("menu");
    }

    // This method is called when the Quit button is pressed
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // If you're testing in the Unity Editor, this doesn't close the editor, but the line below can be used for testing:
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
