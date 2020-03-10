using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //adding useless comment to test push
    private Vector2 inputMovement;
    private Vector2 inputRotation;
    private bool rightStickActive;
    private Rigidbody rb;

    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    public float dashSpeed = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightStickActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("HorizontalRight") >= -.19 && Input.GetAxis("HorizontalRight") <= .19
            && Input.GetAxis("VerticalRight") >= -.19 && Input.GetAxis("VerticalRight") <= .19)
        {
            rightStickActive = false;
        }
            

        Move();
        Look();
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
        Vector3 dash = new Vector3(inputMovement.x, 0, inputMovement.y);
        rb.AddForce(dash * dashSpeed);
    }
}
