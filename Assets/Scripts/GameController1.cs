using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Build.Content;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController1 : MonoBehaviour
{
    GameObject player;
    GameObject iceArch;
    bool lvlChange;
    int index;

    //sound stuff

    //https://answers.unity.com/questions/1335036/change-audio-clip-through-code.html
    // github.com/prismspecs/Virtual-Environments/blob/master/Universal%20RP%20Demos/Assets/Sound/Crossfade%20Songs/Crossfade.cs
    public AudioSource[] audio;
    public AudioClip[] clips;
    int trackNumber;

    // Start is called before the first frame update
    void Start()
    {
        // scene manager
        DontDestroyOnLoad(this.gameObject);
        //index = SceneManager.GetActiveScene().buildIndex;
        trackNumber = 0;
                   

    }

    // Update is called once per frame
    void Update()
    {
        //testing
        if (Input.GetKeyDown("space")) {
            index += 1;
            SceneManager.LoadScene(index);
        }


        player = GameObject.FindGameObjectWithTag("player");


       
    }

    public void play() {

        SceneManager.LoadScene(1);

    }

    public void quit() {

        Application.Quit();

    }

}
