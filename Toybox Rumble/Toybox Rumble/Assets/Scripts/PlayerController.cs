using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private variables
    private Vector2 inputMovement;
    private Vector2 inputRotation;
    private bool rightStickActive;
    private Rigidbody rb;
    private int countFramesDA;
    private int countFramesDash;
    private int countFramesMultiplier;
    private bool hasDashed;

    //public variables
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public float dashSpeed = 10f;
    public float dashAttackSpeed = 10f;
    public float multiplier = 0f;
    public GameObject dashAttackCollider;
    public GameObject multiplierCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightStickActive = false;
        dashAttackCollider.SetActive(false);
        multiplierCollider.SetActive(false);
        countFramesDA = 0;
        countFramesDash = 0;
        countFramesMultiplier = 0;
        hasDashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //allows the user to dash 35 frames after originally dashing
        if (hasDashed == true)
        {
            countFramesDash++;
            if (countFramesDash == 35)
            {
                hasDashed = false;
                countFramesDash = 0;
                Debug.Log(">DASH READY\t" + hasDashed);
            }
        }

        //turns the dashAttackCollider off after 100 frames
        if (dashAttackCollider.activeSelf == true)
        {
            countFramesDA++;
            if (countFramesDA == 100)
            {
                dashAttackCollider.SetActive(false);
                countFramesDA = 0;
                Debug.Log(">DA READY\t" + dashAttackCollider.activeSelf);
            }
        }

        //turns the multiplierCollider off after 15 frames
        if (multiplierCollider.activeSelf == true)
        {
            countFramesMultiplier++;
            if (countFramesMultiplier == 15)
            {
                multiplierCollider.SetActive(false);
                countFramesMultiplier = 0;
                Debug.Log(">Melee READY\t" + multiplierCollider.activeSelf);
            }
        }

        //determines where to look and why
        if (Input.GetAxis("HorizontalRight") >= -.19 && Input.GetAxis("HorizontalRight") <= .19
            && Input.GetAxis("VerticalRight") >= -.19 && Input.GetAxis("VerticalRight") <= .19)
        {
            rightStickActive = false;
        }

        Move();
        Look();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DashAttackHitBox")
        {
            Debug.Log(">DASH ATTACK HIT");
        }
        if(other.tag == "MultiplierHitBox")
        {
            Debug.Log(">MULTIPLIER HIT");
        }
    }

    //Moves the player in the direction of the left stick
    private void Move()
    {
        if (!rightStickActive)
        {
            Vector3 newPosition = new Vector3(inputMovement.x, 0, inputMovement.y);
            Quaternion targetRoatation = Quaternion.LookRotation(newPosition, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(targetRoatation, transform.rotation, rotateSpeed * Time.deltaTime);
        }
        transform.Translate(inputMovement.x * moveSpeed * Time.deltaTime,
                            0, 
                            inputMovement.y * moveSpeed * Time.deltaTime, Space.World); 
    }

    //Rotates the player in the direction of the right stick
    private void Look()
    {
        if (rightStickActive)
        {
            Vector3 lookDirection = new Vector3(inputRotation.x, 0, inputRotation.y);
            Quaternion targetRoatation = Quaternion.LookRotation(lookDirection, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(targetRoatation, transform.rotation, rotateSpeed * Time.deltaTime);
        }
    }

    //On the movement of the left stick, update the vector of the input
    private void OnMove(InputValue v)
    {
        inputMovement = v.Get<Vector2>();
    }

    //On the movement of the right stick, update the vector of the input
    private void OnLook(InputValue v)
    {
        rightStickActive = true;
        inputRotation = v.Get<Vector2>();
    }

    /**
     * Upon the press of the Southern button 
     * (A for xbox, X for playstation), 
     * apply a force in the direction of the left stick
     */
    private void OnDash(InputValue v)
    {
        if (hasDashed == false)
        {
            Vector3 dash = new Vector3(inputMovement.x, 0, inputMovement.y);
            rb.AddForce(dash * dashSpeed);
            hasDashed = true;
        }
    }

    private void OnDashAttack(InputValue v)
    {
        if(dashAttackCollider.activeSelf == false)
        {
            Vector3 dash = new Vector3(inputMovement.x, 0, inputMovement.y);
            rb.AddForce(dash * dashAttackSpeed);
            dashAttackCollider.SetActive(true);
        }
    }

    private void OnMultiplierAttack(InputValue v)
    {
        if(multiplierCollider.activeSelf == false)
        {
            multiplierCollider.SetActive(true);
        }
    }
}
