﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerControllerRewired : MonoBehaviour
{
    private Player player;
    private Player playerOther;
    private Rigidbody rb;
    private CharacterController cc;
    private float moveHorizontal;
    private float moveVertical;
    private float lookHorizontal;
    private float lookVertical;
    private bool rightStickActive;
    private Quaternion playerLook;
    private bool dashInput;
    private bool dashAttackInput;
    private bool hasDashed;
    private int countFramesDash;
    private bool multiplierAttackInput;
    private int countFramesDA;
    private int countFramesMultiplier;
    private bool blockInput;
    private int countThrowFrames;
    private bool shootInput;
    private bool hasDashAttacked;
    private bool otherAnimIsPlaying;
    private bool isThrowing;
    private bool currentlyThrowing;

    //Gameplay Stuff
    public int multiplier;

    public int playerId = 0;
    public int playerOtherId = 1;
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;
    public float dashForce = 1500f;
    public float dashAttackForce = 2000f;
    public GameObject dashAttackCollider;
    public GameObject multiplierCollider;
    public GameObject blockCollider;
    public GameObject projectile;
    public GameObject ProjectileSpawnPoint;
    public int MULTIPLIERDMG = 200;
    public int PROJECTILEDMG = 200;
    public float shootForce = 5000f;
    public Animator anim;

    private void Awake()
    {
        //get Rewired Player Object for this player
        player = ReInput.players.GetPlayer(playerId);
        playerOther = ReInput.players.GetPlayer(playerOtherId);
        //get the Rigidbody
        rb = GetComponent<Rigidbody>();
        //get the CharacterController
        cc = GetComponent<CharacterController>();
        rightStickActive = false;
        //set animator
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ProcessInput();

        //allows the user to dash 35 frames after originally dashing
        if (hasDashed == true)
        {
            countFramesDash++;
            if (countFramesDash == 31)
            {
                hasDashed = false;
                countFramesDash = 0;
                Debug.Log(">DASH READY\t" + hasDashed);
                otherAnimIsPlaying = false;
            }
        }

        //turns the dashAttackCollider off after 100 frames
        if (dashAttackCollider.activeSelf == true)
        {
            countFramesDA++;
            currentlyThrowing = true;
            if (countFramesDA == 100)
            {
                hasDashAttacked = false;
                dashAttackCollider.SetActive(false);
                countFramesDA = 0;
                Debug.Log(">DA READY\t" + dashAttackCollider.activeSelf);
                otherAnimIsPlaying = false;
                currentlyThrowing = false;
            }
        }

        //turns the multiplierCollider off after 15 frames
        if (multiplierCollider.activeSelf == true)
        {
            countFramesMultiplier++;
            if (countFramesMultiplier == 18)
            {
                multiplierCollider.SetActive(false);
                countFramesMultiplier = 0;
                Debug.Log(">Melee READY\t" + multiplierCollider.activeSelf);
                otherAnimIsPlaying = false;
            }
        }

        if(isThrowing == true)
        {
            countThrowFrames++;
            currentlyThrowing = true;
            if(countThrowFrames == 40)
            {
                countThrowFrames = 0;
                otherAnimIsPlaying = false;
                isThrowing = false;
                currentlyThrowing = false;
            }
        }

        //determines where to look and why
        if (Input.GetAxis("HorizontalRight") >= -.19 && Input.GetAxis("HorizontalRight") <= .19
            && Input.GetAxis("VerticalRight") >= -.19 && Input.GetAxis("VerticalRight") <= .19)
        {
            rightStickActive = false;
        }

        transform.rotation = playerLook;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DashAttackHitBox")
        {
            float moveHorizontalPO = playerOther.GetAxis("MoveHorizontal");
            float moveVerticalPO = playerOther.GetAxis("MoveVertical");
            Vector3 vectorOfEnemy = new Vector3(moveHorizontalPO, 0, moveVerticalPO);
            rb.AddForce(vectorOfEnemy * multiplier);
        }

        if (other.tag == "MultiplierHitBox")
        {
            if (blockInput)
            {
                multiplier += 0;
                Debug.Log("Block is registered");
            }
            else
            {
                multiplier += MULTIPLIERDMG;
            }
            Debug.Log(">MULTIPLIER: " + multiplier);
        }

        if (other.tag == "Projectile")
        {
            if (blockInput)
            {
                multiplier += 0;
                Debug.Log("Block is registered");
            }
            else
            {
                multiplier += PROJECTILEDMG;
                Debug.Log(">PROJECTILE: " + multiplier);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "lavaHitBox")
        {
            multiplier += 1;
        }
    }

    private void GetInput()
    {
        if (!blockInput)
        {
            if (!hasDashed)
            {
                if (!hasDashAttacked)
                {
                    //Movement Input
                    moveHorizontal = player.GetAxis("MoveHorizontal");
                    moveVertical = player.GetAxis("MoveVertical");

                    //Look Input
                    lookHorizontal = player.GetAxis("LookHorizontal");
                    lookVertical = player.GetAxis("LookVertical");
                    if (lookHorizontal != 0 || lookVertical != 0)
                    {
                        rightStickActive = true;
                    }

                    //Dash Input
                    dashInput = player.GetButtonDown("Dash");

                    //DashAttack Input
                    dashAttackInput = player.GetButtonDown("DashAttack");

                    //MultiplierAttack Input
                    multiplierAttackInput = player.GetButtonDown("MultiplierAttack");

                    //Shoot Input
                    shootInput = player.GetButtonDown("Shoot");
                }
            }
        }

        //Block Input
        blockInput = player.GetButton("Block");
    }

    private void ProcessInput()
    {
        //Processes movement
        if (!rightStickActive)
        {
            if(moveHorizontal != 0 || moveVertical != 0)
            {
                Vector3 v = new Vector3(moveHorizontal, 0, moveVertical);
                Quaternion q = Quaternion.LookRotation(v, Vector2.up);
                playerLook = Quaternion.RotateTowards(q, transform.rotation, rotateSpeed * Time.deltaTime);
                if (!otherAnimIsPlaying)
                {
                    anim.Play("Walk_Skeleton");
                }
            }
            Vector3 newPosition = new Vector3(moveHorizontal, 0, moveVertical);
            Quaternion targetRoatation = Quaternion.LookRotation(newPosition, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(targetRoatation, transform.rotation, rotateSpeed * Time.deltaTime);
        }
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        if (blockInput)
        {
            movement = new Vector3(0, 0, 0);
        }
        rb.MovePosition(transform.position + movement);

        //Process Looking
        if (rightStickActive)
        {
            if (lookHorizontal != 0 || lookVertical != 0)
            {
                Vector3 v = new Vector3(lookHorizontal, 0, lookVertical);
                Quaternion q = Quaternion.LookRotation(v, Vector2.up);
                playerLook = Quaternion.RotateTowards(q, transform.rotation, rotateSpeed * Time.deltaTime);
                if (!otherAnimIsPlaying)
                {
                    anim.Play("Walk_Skeleton");
                }
            }
            Vector3 lookDirection = new Vector3(lookHorizontal, 0, lookVertical);
            Quaternion targetRoatation = Quaternion.LookRotation(lookDirection, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(targetRoatation, transform.rotation, rotateSpeed * Time.deltaTime);
        }

        //Process Dash
        if (!hasDashed)
        {
            if (dashInput)
            {
                if (moveHorizontal == 0 || moveVertical == 0)
                {
                    Vector3 dashWhileNoInput = this.gameObject.transform.forward;
                    rb.AddForce(dashWhileNoInput * dashForce);
                    hasDashed = true;
                }
                Vector3 dash = new Vector3(moveHorizontal, 0, moveVertical);
                rb.AddForce(dash * dashForce);
                hasDashed = true;
                anim.Play("Dodge_Skeleton");
                otherAnimIsPlaying = true;
            }
        }

        //Process DashAttack
        if (dashAttackInput)
        {
            if (dashAttackCollider.activeSelf == false)
            {
                if (moveHorizontal == 0 || moveVertical == 0)
                {
                    Vector3 dashWhileNoInput = this.gameObject.transform.forward;
                    rb.AddForce(dashWhileNoInput * dashForce);
                    hasDashAttacked = true;
                }
                Vector3 dash = new Vector3(moveHorizontal, 0, moveVertical);
                rb.AddForce(dash * dashAttackForce);
                dashAttackCollider.SetActive(true);
                hasDashAttacked = true;
                anim.Play("Push_Skeleton");
                otherAnimIsPlaying = true;
            }
        }

        //Process Multiplier Attack
        if (multiplierAttackInput)
        {
            if (multiplierCollider.activeSelf == false)
            {
                multiplierCollider.SetActive(true);
                anim.Play("Punch_Skeleton");
                otherAnimIsPlaying = true;
            }
        }

        //Process Block
        if (blockInput)
        {
            if (blockCollider.activeSelf == false)
            {
                blockCollider.SetActive(true);
            }
        }
        else
        {
            if (blockCollider.activeSelf == true)
            {
                blockCollider.SetActive(false);
            }
        }

        //Process Shoot
        if (!currentlyThrowing)
        {
            if (shootInput)
            {
                anim.Play("Throw_Skeleton");
                otherAnimIsPlaying = true;
                isThrowing = true;
                Instantiate(projectile, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
            }
        }
    }
}
