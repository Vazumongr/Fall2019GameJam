using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Gets username from the input feild
      gameObject.GetComponent<InputField>().onEndEdit.AddListener(SubmitUsername);

    }
    public void SubmitUsername( string arg0)
    {
        Globals.userName = arg0;
        Debug.Log(arg0);
    }
}
