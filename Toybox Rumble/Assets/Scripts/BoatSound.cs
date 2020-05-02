using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BoatSound : MonoBehaviour
{
    public UnityEvent StartBoatSound;

    // Start is called before the first frame update
    void Start()
    {
        StartBoatSound.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
