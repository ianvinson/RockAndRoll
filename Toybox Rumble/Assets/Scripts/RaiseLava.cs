using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseLava : MonoBehaviour
{
    public float speed;

    private int countFrames = 0;
    private bool hasRaised = false;

    // Update is called once per frame
    void Update()
    {
        countFrames++;
        //lava raises and stays for this long
        if(countFrames >= 2000 && countFrames <= 2150 && hasRaised == false)
        {
            this.gameObject.transform.Translate(Vector3.up * speed);
        }
        if(countFrames == 2150 && hasRaised == false)
        {
            countFrames = 0;
            hasRaised = true;
        }
        if(countFrames >= 300 && countFrames <= 450 && hasRaised == true)
        {
            this.gameObject.transform.Translate(Vector3.down * speed);
        }
        if(countFrames == 450 && hasRaised == true)
        {
            countFrames = 0;
            hasRaised = false;
        }
    }
}
