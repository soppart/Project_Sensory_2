using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoughControlerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      playerMovement();
    }

    void playerMovement() {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(hor, 0f, ver);
        transform.Translate(PlayerMovement, Space.Self);
        
    }
}
