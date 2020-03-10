using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public PlayerInputManager PIM;

    

    public List<GameObject> Players;

    public float DepthUpdateSpeed = 5f;
    public float AngleUpdateSpeed = 7f;
    public float PositionUpdateSpeed = 5f;

    public float DepthMax = -10f;
    public float DepthMin = -22f;

    public float AngleMaxx = 11f;
    public float AngleMin = 3f;

    private float CameraEulerX;
    private Vector3 CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
