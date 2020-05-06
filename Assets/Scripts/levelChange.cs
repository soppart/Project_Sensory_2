using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelChange : MonoBehaviour
{
    public bool lvlSwitch;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
       index = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
       

        }

    void OnTriggerEnter() {
        Debug.Log("ENTERED!");
        if (index == 5)
        {
            index = 0;
        }

        if (index < 5)
        {
            Debug.Log("less than 5");
            index = index + 1;
            SceneManager.LoadScene(index);
        }
    }
}
