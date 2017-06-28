using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    
    private string targetSceneName;

    private void Start()
    {
        targetSceneName = "Movement_Playground";
        Debug.Log("target scene is " + targetSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SceneChange")
        {
            Debug.Log("collided with SceneChange");
            SceneManager.LoadScene(targetSceneName);

        }
    }
}
