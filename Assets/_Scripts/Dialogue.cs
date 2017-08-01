using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Dialogue : MonoBehaviour {


    //This Script is used to trigger NPC Dialogue dependent on if PlayerCharacter
    //is colliding with the NPC's trigger. If colliding (and player interacts), it starts the Fungus Block
    //set in the inspector, and prevents the player from moving until the block has finished 

    //Things such as conversation options, flow, etc, are handled inside the Fungus Blocks
    
    public Flowchart flowchart;
    public string StartBlock;

    private bool canTalk = false;
    private GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerMovement= player.GetComponent<PlayerMovement>();
    }

    void Update () {
        //if you press space when collider determines canTalk to be true:
        // stop player movement, set CantMove to true in the flowchart, and execute the dialogue block
        if ((Input.GetKeyDown(KeyCode.Space)) && (canTalk == true)){
            flowchart.SetBooleanVariable("CantMove", true);
            playerMovement.StopMovement();
            playerMovement.cantMove = true;
            flowchart.ExecuteBlock(StartBlock);
        }

        //if cant move is false (which is set in the fungus block), set player.cantMove also to false
        if (!flowchart.GetBooleanVariable("CantMove"))
        {
            playerMovement.cantMove = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canTalk = true;
            playerMovement.cantAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canTalk = false;
            playerMovement.cantAttack = false;
        }
    }
}
