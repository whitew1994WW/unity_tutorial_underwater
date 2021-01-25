using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("loadFirstScene", 10f); 
    }

    void loadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

}
