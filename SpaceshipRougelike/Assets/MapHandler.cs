using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapHandler : MonoBehaviour
{
    //1 = where you are
    public AudioSource AS;

    int[] MapList = {0, 0, 0, 0, 0, 0, 0,
                     1, 0, 0, 0, 0, 0, 0,
                     0, 0, 0, 0, 0, 0, 0};

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //idk why I did this in this file
    //update, it was becauase I was lazy
    public void nextSence()
    {
        SceneManager.LoadScene(2);
    }
    public void playSound()
    {
        AS.Play();
    }
}
