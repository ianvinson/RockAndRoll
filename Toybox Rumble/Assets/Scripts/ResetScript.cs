﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{

    public GameObject Skeleton;
    public GameObject Robot;
    public GameObject P1S_1, P1S_2, P1S_3;
    public GameObject P2S_1, P2S_2, P2S_3;
    public int P1StockCount = 3, P2StockCount = 3;

    public UnityEvent PlayResetSound;
    public UnityEvent PlaySkeletonDefeatSound;
    public UnityEvent PlayRobotDefeatSound;

    private Scene activeScene;

    private void Update()
    {
        activeScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //reset position
            if (activeScene.name == "Boat_Level")
            {
                if (other.name == "Skeleton")
                {
                    PlaySkeletonDefeatSound.Invoke();
                    PlayResetSound.Invoke();
                    Skeleton.transform.position = new Vector3(-34.5f, 13.32962f, 9.1f);
                }
                else
                {
                    PlayRobotDefeatSound.Invoke();
                    PlayResetSound.Invoke();
                    Robot.transform.position = new Vector3(-0.36f, 13.17f, 9.71f);
                }
            }
            else
            {
                if (other.name == "Skeleton")
                {
                    PlaySkeletonDefeatSound.Invoke();
                    PlayResetSound.Invoke();
                    Skeleton.transform.position = new Vector3(-35.34643f, 16.03313f, 33.32971f);
                }
                else
                {
                    PlayRobotDefeatSound.Invoke();
                    PlayResetSound.Invoke();
                    Robot.transform.position = new Vector3(11.93107f, 16.32862f, -12.26073f);
                }
            }

            //reset dmg/multiplier
            if (other.name == "Skeleton")
            {
                Skeleton.GetComponent<SkeletonControllerRewired>().multiplier = 0;
                if(P1StockCount == 3)
                {
                    P1StockCount--;
                    P1S_1.SetActive(false);
                }
                else if (P1StockCount == 2)
                {
                    P1StockCount--;
                    P1S_2.SetActive(false);
                }
                else if (P1StockCount == 1)
                {
                    P1StockCount--;
                    P1S_3.SetActive(false);
                }
            }
            if (other.name == "Robot")
            {
                Robot.GetComponent<RobotControllerRewired>().multiplier = 0;
                if (P2StockCount == 3)
                {
                    P2StockCount--;
                    P2S_1.SetActive(false);
                }
                else if (P2StockCount == 2)
                {
                    P2StockCount--;
                    P2S_2.SetActive(false);
                }
                else if (P2StockCount == 1)
                {
                    P2StockCount--;
                    P2S_3.SetActive(false);
                }
            }

            //reset velocity
            Skeleton.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Robot.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
