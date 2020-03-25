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
        multiplierText.text = player.GetComponent<PlayerControllerRewired>().multiplier.ToString() + "*";

    }
}
