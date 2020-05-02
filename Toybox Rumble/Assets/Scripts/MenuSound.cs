using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuSound : MonoBehaviour
{
    public UnityEvent StartMenuMusic;
    public UnityEvent StopMenuMusic;
    public UnityEvent PlayMenuClick;

    // Start is called before the first frame update
    void Start()
    {
        StartMenuMusic.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene().name == "Lava_Level" || SceneManager.GetActiveScene().name == "Boat_Level")
        //{
        //    StopMenuMusic.Invoke();
        //}
    }
}
