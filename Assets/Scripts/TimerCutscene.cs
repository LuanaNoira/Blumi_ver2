using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCutscene : MonoBehaviour
{
    public string levelToLoad;
    private float timer = 55f;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            SceneManager.LoadScene("Planicie");
        }
    }
}
