using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LavaSound : MonoBehaviour
{
    public UnityEvent StartLavaSound;

    // Start is called before the first frame update
    void Start()
    {
        StartLavaSound.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
