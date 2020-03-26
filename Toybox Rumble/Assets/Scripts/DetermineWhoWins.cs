using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetermineWhoWins : MonoBehaviour
{
    public GameObject resetHitBox;
    public GameObject blueWins;
    public GameObject redWins;
    public GameObject blueWinsButton;
    public GameObject redWinsButton;

    private int P1StockCount;
    private int P2StockCount;

    // Update is called once per frame
    void Update()
    {
        P1StockCount = resetHitBox.GetComponent<ResetScript>().P1StockCount;
        P2StockCount = resetHitBox.GetComponent<ResetScript>().P2StockCount;

        if(P1StockCount == 0)
        {
            redWins.SetActive(true);
            redWinsButton.SetActive(true);
        }
        if (P2StockCount == 0)
        {
            blueWins.SetActive(true);
            blueWinsButton.SetActive(true);
        }
    }
}
