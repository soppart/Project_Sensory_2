using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;

    public Vector3 playerPos;
    private Vector3 cameraDist = new Vector3(0f, 30f, 0f);
    private float cameraHeight = 30f;
  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        camera.transform.position = playerPos + cameraDist;
        cameraHeight = Mathf.Pow(Move2.ballRadius, 1f) * 8;
        cameraDist = new Vector3(0f, cameraHeight, -20f);
    }
}
