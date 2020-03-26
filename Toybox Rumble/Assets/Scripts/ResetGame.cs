using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject Player1, Player2;
    public GameObject P1S_1, P1S_2, P1S_3;
    public GameObject P2S_1, P2S_2, P2S_3;
    public GameObject blueWins, redWins;
    public GameObject blueWinsButton, redWinsButton;
    public GameObject gameLogic;

    public void resetGame()
    {
        //reset win screen
        //blue wins
        blueWins.SetActive(false);
        blueWinsButton.SetActive(false);
        //red wins
        redWins.SetActive(false);
        redWinsButton.SetActive(false);

        //Set both players to active
        Player1.SetActive(true);
        Player2.SetActive(true);

        //reset position
        Player1.transform.position = new Vector3(-33.7f, 13.32962f, 10.3f);
        Player2.transform.position = new Vector3(11.3f, 13.32962f, 11f);

        //reset multiplier
        Player1.GetComponent<PlayerControllerRewired>().multiplier = 0;
        Player2.GetComponent<PlayerControllerRewired>().multiplier = 0;

        //reset velocity
        Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //reset stocks
        //P1
        P1S_1.SetActive(true);
        P1S_2.SetActive(true);
        P1S_3.SetActive(true);
        gameLogic.GetComponent<ResetScript>().P1StockCount = 3;
        //P2
        P2S_1.SetActive(true);
        P2S_2.SetActive(true);
        P2S_3.SetActive(true);
        gameLogic.GetComponent<ResetScript>().P2StockCount = 3;
    }
}
