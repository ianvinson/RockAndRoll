using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScript : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;
    public GameObject P1S_1, P1S_2, P1S_3;
    public GameObject P2S_1, P2S_2, P2S_3;
    public GameObject blueWins, redWins;
    public GameObject blueWinsButton, redWinsButton;

    public int countStocksP1 = 3;
    public int countStocksP2 = 3;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player1" || other.name == "Player2")
        {
            //Remove blue stock
            if (other.name == "Player1")
            {
                if (countStocksP1 == 3)
                {
                    countStocksP1--;
                    P1S_3.SetActive(false);
                }
                else if (countStocksP1 == 2)
                {
                    countStocksP1--;
                    P1S_2.SetActive(false);
                }
                else if (countStocksP1 == 1)
                {
                    countStocksP1--;
                    P1S_1.SetActive(false);
                }
            }

            //remove red stock
            if (other.name == "Player2")
            {
                if (countStocksP2 == 3)
                {
                    countStocksP2--;
                    P2S_1.SetActive(false);
                }
                else if (countStocksP2 == 2)
                {
                    countStocksP2--;
                    P2S_2.SetActive(false);
                }
                else if (countStocksP2 == 1)
                {
                    countStocksP2--;
                    P2S_3.SetActive(false);
                }
            }

            //reset position
            //Reset for blue
            if (countStocksP1 == 0)
            {
                Player1.SetActive(false);
            }
            if (countStocksP1 != 0)
            {
                Player1.transform.position = new Vector3(-33.7f, 13.32962f, 10.3f);
            }

            //reset for red
            if(countStocksP2 == 0)
            {
                Player2.SetActive(false);
            }
            if (countStocksP2 != 0)
            {
                Player2.transform.position = new Vector3(11.3f, 13.32962f, 11f);
            }

            //reset dmg/multiplier
            if (other.name == "Player1")
            {
                Player1.GetComponent<PlayerControllerRewired>().multiplier = 0;
            }
            if (other.name == "Player2")
            {
                Player2.GetComponent<PlayerControllerRewired>().multiplier = 0;
            }

            //reset velocity
            Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

    }
}
