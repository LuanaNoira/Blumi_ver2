using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public string levelToLoad;
    private float timer = 6f;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
