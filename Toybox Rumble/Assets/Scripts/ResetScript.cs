using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //reset position
            Player1.transform.position = new Vector3(-33.7f, 13.32962f, 10.3f);
            Player2.transform.position = new Vector3(11.3f, 13.32962f, 11f);
            //reset dmg/multiplier
            Player1.GetComponent<PlayerControllerRewired>().multiplier = 0;
            Player2.GetComponent<PlayerControllerRewired>().multiplier = 0;
            //reset velocity
            Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
