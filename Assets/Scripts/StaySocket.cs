using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaySocket : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform MySocket;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = MySocket.position;
    }
}
