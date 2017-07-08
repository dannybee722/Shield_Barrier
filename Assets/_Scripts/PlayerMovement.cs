using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovingObject {

    public static PlayerMovement instance = null;

    public Animator animator;
    public float speed = 1.0f;

    private int moveDir;
    private float moveHoriz;
    private float moveVert;
    
    private Rigidbody2D rigid;

    private Vector3 move;

    // Use this for initialization
    private void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        rigid = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        base.Start();
	}

    private void FixedUpdate()
    {

        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //transform.position += move * speed * Time.deltaTime;
        rigid.velocity = move * speed;

    }

    // Update is called once per frame
    void Update () {

        moveHoriz = Input.GetAxisRaw("Horizontal");
        moveVert = Input.GetAxisRaw("Vertical");

        MoveDir(moveHoriz, moveVert);
    }

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
}
