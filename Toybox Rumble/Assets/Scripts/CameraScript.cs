using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Camera thisCam;

    // Start is called before the first frame update
    void Start()
    {
        thisCam.transform.position = new Vector3(-11.59995f, 73.31589f, -23.76174f);
    }

    // Update is called once per frame
    void Update()
    {
        FixedCameraFollowSmooth(thisCam, Player1.transform, Player2.transform);
    }

    //THE FOLLOWING CODE IS PROVIDED BY: TreyH @ https://answers.unity.com/questions/1142089/moving-camera-with-2-players.html
    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 3f;
        float followTimeDelta = .08f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude / 2f;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        //Keeps camera from zooming in too much
        if (cameraDestination.x >= 50)
        {
            cameraDestination.x = 50;
        }
        if (cameraDestination.y <= 40)
        {
            cameraDestination.y = 40;
        }
        if (cameraDestination.z >= 55)
        {
            cameraDestination.z = 55;
        }

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }
}
