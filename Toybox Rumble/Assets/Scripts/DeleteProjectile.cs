using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteProjectile : MonoBehaviour
{
    private int countFrames = 0;

    // Update is called once per frame
    void Update()
    {
        countFrames++;
        if(countFrames == 100)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
