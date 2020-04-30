using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void resetGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
