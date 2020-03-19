using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountdownClock : MonoBehaviour
{
    public Text countdownClock;
    private int clock;
    bool twoMinute;
    AudioSource track;
    public GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        track = GetComponent<AudioSource>();
        twoMinute = true;
        StartCoroutine("CountDown");
        track.Play();
        clock = 120;
        
    }

    // Update is called once per frame
    void Update()
    {
        //count down
        countdownClock.text = ("" + clock);
        if (clock <= 0)
        {
            if(twoMinute)
            {
                twoMinute = false;
                clock = 5;
                fader.GetComponent<FadeToBlack>().fadeToBlack();
                //StartCoroutine("CountDown");
            }
            else
                DoomsDay();
        }
    }
    //timer
    IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            clock--;
        }

    }
    //ends after the times up
    void DoomsDay()
    {
        SceneManager.LoadScene(4);
    }
}
