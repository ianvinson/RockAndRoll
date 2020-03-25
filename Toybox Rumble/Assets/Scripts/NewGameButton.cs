using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void NextScene()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            SceneManager.LoadScene("Level Selection");
        }
        else if (SceneManager.GetActiveScene().name == "Level Selection")
        { 
            SceneManager.LoadScene("Character Selection"); 
        }

        else if (SceneManager.GetActiveScene().name == "Character Selection")
        {
            SceneManager.LoadScene("Playground");
        }



    }
}