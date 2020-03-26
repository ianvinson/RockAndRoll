using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;
    public GameObject P1S_1, P1S_2, P1S_3;
    public GameObject P2S_1, P2S_2, P2S_3;
    public int P1StockCount = 3, P2StockCount = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //reset position
            Player1.transform.position = new Vector3(-33.7f, 13.32962f, 10.3f);
            Player2.transform.position = new Vector3(11.3f, 13.32962f, 11f);

            //reset dmg/multiplier
            if (other.name == "Player1")
            {
                Player1.GetComponent<PlayerControllerRewired>().multiplier = 0;
                if(P1StockCount == 3)
                {
                    P1StockCount--;
                    P1S_1.SetActive(false);
                }
                else if (P1StockCount == 2)
                {
                    P1StockCount--;
                    P1S_2.SetActive(false);
                }
                else if (P1StockCount == 1)
                {
                    P1StockCount--;
                    P1S_3.SetActive(false);
                }
            }
            if (other.name == "Player2")
            {
                Player2.GetComponent<PlayerControllerRewired>().multiplier = 0;
                if (P2StockCount == 3)
                {
                    P2StockCount--;
                    P2S_1.SetActive(false);
                }
                else if (P2StockCount == 2)
                {
                    P2StockCount--;
                    P2S_2.SetActive(false);
                }
                else if (P2StockCount == 1)
                {
                    P2StockCount--;
                    P2S_3.SetActive(false);
                }
            }

            //reset velocity
            Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
