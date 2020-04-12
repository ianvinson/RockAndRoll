using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 movementVector;
    public GameObject bep;

    
    // Start is called before the first frame update
    void Start()
    {
        movementVector = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + movementVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            bep.SetActive(true);
            //bep.transform.position = this.gameObject.transform.position;
            bep.GetComponent<ParticleSystem>().Play();
            GameObject.Destroy(this.gameObject);
        }
    }

}
