using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovingObject {

    public Animator animator;
    public float speed = 1.0f;

    private int moveDir;
    private float moveHoriz;
    private float moveVert;

    private Vector3 move;

    // Use this for initialization
    protected override void Start () {
        animator = GetComponent<Animator>();

        base.Start();
	}
	
	// Update is called once per frame
	void Update () {

        moveHoriz = Input.GetAxisRaw("Horizontal");
        moveVert = Input.GetAxisRaw("Vertical");

        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.fixedDeltaTime;

        MoveDir(moveHoriz, moveVert);

        Debug.Log("Horiz " + moveHoriz);
        Debug.Log("Vert " + moveVert);
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
    }
}
