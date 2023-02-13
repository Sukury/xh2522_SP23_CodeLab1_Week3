using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWASDController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float ForceAmount = 50;
    public Animator animator;
    private bool down = false;
    private bool up = false;
    private bool left = false;
    private bool right = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up*ForceAmount);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            animator.SetBool("up",true);
        }
        else
        {
            animator.SetBool("up",false);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down*ForceAmount);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            animator.SetBool("down",true);
        }
        else
        {
            down = false;
            animator.SetBool("down",false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left*ForceAmount);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            animator.SetBool("left",true);
        }
        else
        {
            left = false;
            animator.SetBool("left",false);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right*ForceAmount);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            animator.SetBool("right",true);
        }
        else
        {
            right = false;
            animator.SetBool("right",false);
        }

        rb2d.velocity *= .9f;
        

    }
}
