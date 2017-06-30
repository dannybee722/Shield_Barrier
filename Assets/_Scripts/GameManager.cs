using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public Transform destination;

    private Vector3 camOffset = new Vector3 (0f, 0f, 1.5f);
    public static GameManager GMinstance = null;

    private void Awake()
    {
        if (GMinstance == null)
        {
            GMinstance = this;
        }
        if (GMinstance != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //player.transform.position = destination.position;
        mainCamera.GetComponent<SmoothCam>().target = player.transform;
        mainCamera.GetComponent<SmoothCam>().target.position += camOffset;
        Debug.Log(destination.position);
    }

}


