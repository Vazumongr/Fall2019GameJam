using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public ParticleSystem particles;
    SpriteRenderer playerSprite;

    public CameraShake cameraShake;

    Animator animation;
    public int speed;
    public int height;
    float moveHor;
    float moveVer;
    public bool isGrounded;
    public bool hasJumped;
    List<float> poolColors;     //keeps track of the colors we want to switch too
    List<float> selectedColors; //Keeps track of all the colors we have switched too

    Vector2 original;
    RaycastHit2D grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        animation = GetComponentInChildren<Animator>();
        original = new Vector2(9, 0);
        poolColors = new List<float>() {0f, .125f, .25f, .375f, .5f, .625f, .75f, .875f};   //Animations are based off percentage of the animation. You cant do frames and its garbage. At least to my knowledge.
        selectedColors = new List<float>();
    }
    void FixedUpdate()
    {
        //Checks when you hold and release the D button
        if (Input.GetKey(KeyCode.D)){
            
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }else if(Input.GetKeyUp(KeyCode.D)){
            rb.velocity = new Vector2(speed/4, rb.velocity.y);
        }
        //Checks when you hold and release the A button
        if (Input.GetKey(KeyCode.A)){
          
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed/4, rb.velocity.y);
        }
        //Checks when you press the Space button
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
           
            rb.velocity = new Vector2(rb.velocity.x, height);
            hasJumped = true;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Checks when the player is on the ground
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            ChangeColor();
            StartCoroutine(cameraShake.Shake(.15f,.4f));





            /*This will simply play the particles effect
            when ever we hit a surface. The hasJumped
            is just so it doesn't spawn particles on start.
            It helps add to the surprise */
            if(hasJumped)
                particles.Play();

        }
       
    }

    //Resposible for changing the color of the player block
    private void ChangeColor()
    {
        //Sets the speed to 0 so it doesn't run through and cause seizxures
        animation.speed = 0f;

        if(poolColors.Count>0)
        {
            
            int frame = Random.Range(0,poolColors.Count);   //Picks random color
            selectedColors.Add(poolColors[frame]);          //Adds selected color to the the selected colors list
            animation.Play("Player_Color",0,poolColors[frame]); //Sets the selected color
            poolColors.RemoveAt(frame);                     //Removes the selected color from the pool so you don't get repeats
            //Debug.Log("Color pool left: " + PrintList(poolColors));
            //Debug.Log("Colors selected already: " + PrintList(selectedColors));
            //Debug.Log("******************************************************");
        }
        if(!(poolColors.Count>0))   //Once we cycled through all the colors
        {
            //Debug.Log(selectedColors.Count);
            int temp = selectedColors.Count;    //Get the length because we need it to not change
            /*This has to work backwards because as you remove it from the 
            selectedColors list, the list shrinks in size. */
            for(int i=temp-1;i>=0;i--)
            {
                poolColors.Add(selectedColors[i]);  //Adds the color back to the pool
                selectedColors.RemoveAt(i);         //Removes it from the selected color list
            }
            //Debug.Log("Color pool left: " + PrintList(poolColors));
            //Debug.Log("Colors selected already: " + PrintList(selectedColors));
        }

    }

    //Simply prints the contents of a list, mainly for debugging purposes
    private string PrintList(List<float> list)
    {
        string contents = "";
        for(int i = 0; i < list.Count; i++)
        {
            contents = contents + list[i].ToString() + " ";
        }
        return contents;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks when the player is at the end of the level
        if (other.gameObject.tag == "End")
        {
            Globals.completedCounter = Globals.completedCounter + 1;
            gameObject.transform.position = original;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        //Checks when the player leaves the ground
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    

    //Find out if we are grounded or not.
    public bool Grounded()
    {
        return isGrounded;
    }


}
