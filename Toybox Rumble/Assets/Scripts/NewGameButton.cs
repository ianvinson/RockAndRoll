using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NewGameButton : MonoBehaviour
{

    public void NextScene()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu" && GetMenuItems.getMenuName() == "Quit")
        {
            Application.Quit();
        }
        else if (SceneManager.GetActiveScene().name == "Options" && GetMenuItems.getMenuName() == "Main Menu")
        {
            SceneManager.LoadScene(GetMenuItems.getMenuName());
        }
        else if (SceneManager.GetActiveScene().name == "Main Menu" && GetMenuItems.getMenuName() == "Options")
        {
            SceneManager.LoadScene(GetMenuItems.getMenuName());
        }
        //this sends you to level selection from the main menu
        else if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            SceneManager.LoadScene("Level Selection");
        }
        //this sends you to character selection from level selection
        else if (SceneManager.GetActiveScene().name == "Level Selection")
        {
            SceneManager.LoadScene("Character Selection");
        }
        //this sends you from character selection to game
        else if (SceneManager.GetActiveScene().name == "Character Selection")
        {
            Debug.Log(">" + GetMenuItems.getLevelName());
            SceneManager.LoadScene(GetMenuItems.getLevelName());
        }
    }

    public void setLevelNameToLava()
    {
        GetMenuItems.setLevelName("Lava_Level");
    }
    public void setLevelNameToBoat()
    {
        GetMenuItems.setLevelName("Boat_Level");
    }

    public void setCharacterPlayer1Skeleton()
    {
        DeterminePlayerCharacter.setNum(0);
    }
    public void setCharacterPlayer1Robot()
    {
        DeterminePlayerCharacter.setNum(1);
    }

    public void setMenuNameToOptions()
    {
        GetMenuItems.setMenuName("Options");
    }

    public void setMenuNameToMainMenu()
    {
        GetMenuItems.setMenuName("Main Menu");
    }

    public void setMenuNameToQuit()
    {
        GetMenuItems.setMenuName("Quit");
    }
}