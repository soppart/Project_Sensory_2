using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float moveSpd = 20.0f;

    float ballRadius = 5.0f;
    Vector3 ballSize;

    float GrowSpd;

    float rotationSpeed;
    Quaternion targetOrientation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ballSize = new Vector3(ballRadius, ballRadius, ballRadius);
        transform.localScale = ballSize;
        rotationSpeed = ballRadius * 40;
        GrowSpd = 5f / ballRadius;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpd * Time.deltaTime);
            targetOrientation = Quaternion.Euler(1, 0, 0) * targetOrientation;
            ballRadius += GrowSpd * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpd * Time.deltaTime, 0, 0);
            targetOrientation = Quaternion.Euler(0, 0, 1) * targetOrientation;
            ballRadius += GrowSpd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveSpd * Time.deltaTime);
            targetOrientation = Quaternion.Euler(-1, 0, 0) * targetOrientation;
            ballRadius += GrowSpd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpd * Time.deltaTime, 0, 0);
            targetOrientation = Quaternion.Euler(0, 0, -1) * targetOrientation;
            ballRadius += GrowSpd * Time.deltaTime;
        }
        
        transform.rotation = targetOrientation;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ice")
        {
   
        }
    }
}
