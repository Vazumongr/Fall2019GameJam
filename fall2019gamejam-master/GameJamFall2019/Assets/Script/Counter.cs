using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text completed;
    // Update is called once per frame
    void Update()
    {
        //Puts the counter for your completed runs
        completed.text = Globals.userName + " has completed: " + Globals.completedCounter;
    }
}
