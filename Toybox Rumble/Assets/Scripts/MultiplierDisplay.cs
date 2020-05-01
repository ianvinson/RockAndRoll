using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierDisplay : MonoBehaviour
{
    public GameObject player;
    public Text multiplierText;

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.name == "Robot")
        {
            multiplierText.text = player.GetComponent<RobotControllerRewired>().multiplier.ToString() + "%";
        }
        else
        {
            multiplierText.text = player.GetComponent<SkeletonControllerRewired>().multiplier.ToString() + "%";
        }
    }
}
