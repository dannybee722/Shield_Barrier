using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public Animator animator;
    private PlayerMovement playerMovement;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")){
            animator.SetTrigger("attack");
        }
	}
}
