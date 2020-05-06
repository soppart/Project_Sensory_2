using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2 : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject ground;

    public float planeStatus = 1;
    int constraintStatus = 1;

    private float pushForce = 60f;
    private float boostForce = 50f;
    private Vector3 ballPosition = new Vector3(0f, 0f, 0f);
    private Vector3 StartPosition = new Vector3(-100f, 2f, 0f);

    public static float ballRadius = Mathf.Clamp(5f, 2.5f, 12f);
    Vector3 ballSize;
    float GrowSpd;
    //float minGlideSpd = Mathf.Clamp(10, 10, 10);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ballSize = new Vector3(ballRadius, ballRadius, ballRadius);
        transform.localScale = ballSize;
        GrowSpd = 5f / ballRadius;
        this.gameObject.GetComponent<Rigidbody>().AddForce(0, -80, 0, ForceMode.Acceleration);

        //if (constraintStatus == 2)
        //{
        //    rb.constraints = RigidbodyConstraints.None;
        //    rb.constraints = RigidbodyConstraints.FreezePositionZ;
        //}
        //else if (constraintStatus == 3)
        //{
        //    rb.constraints = RigidbodyConstraints.None;
        //    rb.constraints = RigidbodyConstraints.FreezePositionX;
        //}

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (planeStatus == 2)
        {
            rb.drag = 0f;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            if (GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                planeStatus = 3;
            }
            if (Mathf.Abs(rb.velocity.x) > 0 && Mathf.Abs(rb.velocity.z) > 0)
            {
                if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.z))
                {
                    Vector3 vel = rb.velocity;
                    vel.z = 0f;
                    rb.velocity = vel;
                    if (Mathf.Abs(rb.velocity.x) < 12)
                    {
                        //rb.velocity.x ++;
                    }
                    if (Mathf.Abs(rb.velocity.x) < 0.5f)
                    {
                        planeStatus = 3;
                    }
                }
                else
                {
                    Vector3 vel = rb.velocity;
                    vel.x = 0f;
                    rb.velocity = vel;
                    if (Mathf.Abs(rb.velocity.z) < 12)
                    {
                        //rb.velocity.z ++;
                    }
                    if (Mathf.Abs(rb.velocity.z) < 0.5f)
                    {
                        planeStatus = 3;
                    }
                }
            }

        }
        else if (planeStatus == 1)
        {
            rb.drag = 5;
            rb.constraints = RigidbodyConstraints.None;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, pushForce, ForceMode.Acceleration);
                    constraintStatus = 3;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -pushForce, ForceMode.Acceleration);
                    constraintStatus = 3;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(-pushForce, 0, 0, ForceMode.Acceleration);
                    constraintStatus = 2;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(pushForce, 0, 0, ForceMode.Acceleration);
                    constraintStatus = 2;
                }
                //ballRadius += GrowSpd * Time.deltaTime;
            }
        }
        else if (planeStatus == 3)
        {
            rb.constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, boostForce, ForceMode.VelocityChange);
                planeStatus = 2;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -boostForce, ForceMode.VelocityChange);
                planeStatus = 2;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(-boostForce, 0, 0, ForceMode.VelocityChange);
                planeStatus = 2;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(boostForce, 0, 0, ForceMode.VelocityChange);
                planeStatus = 2;
            }
        }
        else if (planeStatus == 4)
        {
            ballRadius += GrowSpd * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ice")
        {
            Debug.Log("EnterIce");
            planeStatus = 2;
        }
        if (other.tag == "block")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            planeStatus = 3;
        }
        
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "block")
        {
            //planeStatus = 2;
        }
        if (other.tag == "ice")
        {
            
            planeStatus = 1;
        }
    }
}
