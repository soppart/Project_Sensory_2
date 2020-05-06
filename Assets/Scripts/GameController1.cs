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

    // Start is called before the first frame update
    void Start()
    {
        // scene manager
        DontDestroyOnLoad(this.gameObject);
                         

    }

    // Update is called once per frame
    void Update()
    {
        
         player = GameObject.FindGameObjectWithTag("player");
               
    }

    public void play() {

        SceneManager.LoadScene(1);

    }

    public void quit() {

        Application.Quit();

    }

}
