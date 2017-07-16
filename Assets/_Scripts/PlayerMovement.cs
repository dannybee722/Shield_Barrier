using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerMovement : MovingObject {

    public static PlayerMovement instance;

    public Animator animator;
    public float speed = 1.0f;

    private int moveDir;
    private float moveHoriz;
    private float moveVert;
    
    private Rigidbody2D rigid;

    private Vector3 move;

    //to be used by other scripts, (fungus conversations, scene transitions) to prevent 
    //character from moving and performing animations when not intended
    public bool cantMove = false;
    public bool cantAttack = false;

    // Use this for initialization
    protected override void Start () {
        instance = this;

        rigid = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        base.Start();
	}

    private void FixedUpdate()
    {

        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //transform.position += move * speed * Time.deltaTime;
        if (cantMove != true)
        {
            rigid.velocity = move * speed;

            moveHoriz = Input.GetAxisRaw("Horizontal");
            moveVert = Input.GetAxisRaw("Vertical");

            MoveDir(moveHoriz, moveVert);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //as long as movement is allowed (and you're not standing in an NPC conversation trigger, allow movement````
        if (!cantMove && !cantAttack)
        {
            if (Input.GetKeyDown("space"))
            {
                animator.SetTrigger("attack");
            }
        }
        
    }

    //sets movement direction based on 'horiz' and 'vert' values
    private void MoveDir(float horiz, float vert)
    {
        //if we're moving right, and up/down val is between(incl) +/- 0.5, keep animation as moving right
        if ((horiz > 0 && (vert >= 0 && vert <= 0.5)) || (horiz > 0 && ( vert <= 0 && vert >= -0.5)))
        {
            animator.SetTrigger("runRight");
        }

        //if we're moving left, and up/down val is between(incl) +/- 0.5, keep animation as moving left
        else if ((horiz < 0 && (vert >= 0 && vert <= 0.5)) || (horiz < 0 && (vert <= 0 && vert >= -0.5)))
        {
            animator.SetTrigger("runLeft");
        }
        
        //if we're moving up, and left/right val is between(incl) +/- 0.5, keep animation as moving left
        else if ((vert > 0 && (horiz >= 0 && horiz <= 0.5)) || (vert > 0 && (horiz <= 0 && horiz >= -0.5)))
        {
            animator.SetTrigger("runUp");
        }
        
        //if we're moving down, and left/right val is between(incl) +/- 0.5, keep animation as moving left
        else if ((vert < 0 && (horiz >= 0 && horiz <= 0.5)) || (vert < 0 && (horiz <= 0 && horiz >= -0.5)))
        {
            animator.SetTrigger("runDown");
        }

        else if (vert == 0 && horiz == 0)
        {
            animator.SetTrigger("idle");
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("collided");
    }

    public void StopMovement ()
    {
        cantMove = true;
        rigid.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        MoveDir(0, 0);
    }
    
}
