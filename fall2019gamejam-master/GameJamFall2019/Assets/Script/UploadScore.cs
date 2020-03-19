using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UploadScore : MonoBehaviour
{
    public void UpdateScore(bool pressed)
    {
        //writes name and score into leaderboards.
        if (pressed)
            Leaderboards.fileWriter();
        
    }
}
