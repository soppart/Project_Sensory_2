using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    bool inFireRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inFireRange == true)
        {
            if (Move2.ballRadius > 2) { 
            Debug.Log("infire");
            Move2.ballRadius -= 2 * Time.deltaTime;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            inFireRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            inFireRange = false;
        }
    }
}
