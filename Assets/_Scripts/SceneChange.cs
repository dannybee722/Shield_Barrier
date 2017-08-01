using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class SceneChange : MonoBehaviour {
    
    [Tooltip("naming convention of blocks is 'ToSceneName'")]
    public string fungusBlockToCall;
    public Flowchart flowchart;

    private void Start()
    {
        Debug.Log(": fungus block is " + fungusBlockToCall);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().StopMovement();
            flowchart.ExecuteBlock(fungusBlockToCall);
        }
    }
}
