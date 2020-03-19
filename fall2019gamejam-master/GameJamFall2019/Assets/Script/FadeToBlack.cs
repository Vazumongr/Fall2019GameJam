using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    Animator fader;
    // Start is called before the first frame update
    void Start()
    {
        fader = GetComponent<Animator>();
        fader.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fadeToBlack()
    {
        Debug.Log("i have been called");
        fader.speed = 1;
    }
}
