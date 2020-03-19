using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    public float distance;
    public GameObject holder;

  
    public float minCamera;
    public float maxCamera;
    void Start()
    {
        //Finds Player object
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        //Camera follows the player and gets Clamped.
        Vector3 targetPosition = player.position;
        float y = Mathf.Clamp(player.position.y, minCamera, maxCamera);
        holder.transform.position = new Vector3(0, y, holder.transform.position.z); //I had to create a camera holder object and move that instead of the camera to do the camera shaking.
    }
}
