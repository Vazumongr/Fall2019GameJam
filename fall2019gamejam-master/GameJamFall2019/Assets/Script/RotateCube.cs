using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    private Quaternion originalRotation;
    public float rotationSpeed = 10f;
   
    bool notRotate = false;
    // Start is called before the first frame update
    void Start()
    {
      originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        RotationCube();
        Original();
    }

    void RotationCube()
    {
        //Only want to rotate while airborne or things get weird.
        if(!GetComponentInParent<PlayerController>().Grounded())
        {
            //Checks when you press and release the space bar to rotate the square
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Rotate(Vector3.back * rotationSpeed);
                notRotate = false;
            }
            else
            {
                notRotate = true;
            }
            //Checks when you are holding the D button to rotate the square
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.back * rotationSpeed);
                notRotate = false;
            }
            //Checks when you are holding the A button to rotate the square
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.back * rotationSpeed);
                notRotate = false;
            }
            else
            {
                notRotate = true;
            }
        }
        else
            notRotate = true;
    }
    void Original()
    {
        //Resets the rotation when not being pressed.
        if(notRotate)
             transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * rotationSpeed);
    }
}
