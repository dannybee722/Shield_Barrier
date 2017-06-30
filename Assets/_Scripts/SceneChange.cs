using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    
    public string sceneToLoad;
    public string spawnPoint;
    public Vector3 spoint;

    private void Start()
    {
        Debug.Log(": target scene is " + sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DontDestroyOnLoad(other.gameObject);
            DontDestroyOnLoad(this);
            GameManager.GMinstance.destination.position = spoint;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
