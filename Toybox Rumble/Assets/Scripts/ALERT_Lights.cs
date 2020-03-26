using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALERT_Lights : MonoBehaviour
{
    public GameObject L1, L2, L3, L4, text;

    private int countFrames = 0;
    private bool hasRaised = false;

    // Update is called once per frame
    void Update()
    {
        countFrames++;
        //lava raises and stays for this long
        if (countFrames >= 1725 && countFrames <= 2150)
        {
            if (countFrames % 10 == 0)
            {
                L1.SetActive(true);
                L2.SetActive(true);
                L3.SetActive(true);
                L4.SetActive(true);
                text.SetActive(true);
            }
            if (countFrames % 30 == 0)
            {
                L1.SetActive(false);
                L2.SetActive(false);
                L3.SetActive(false);
                L4.SetActive(false);
                text.SetActive(false);
            }
        }
        if (countFrames == 2150)
        {
            countFrames = 0;
            L1.SetActive(false);
            L2.SetActive(false);
            L3.SetActive(false);
            L4.SetActive(false);
            text.SetActive(false);
        }
    }
}
