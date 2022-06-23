using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 5;
    public TextMeshProUGUI playerHPText;
    public static bool isGameOver = false;

    //[SerializeField] Transform playerPos;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseMenu;
    public Transform startPos;
    [SerializeField] private GameObject unconciusScreen;

    float timer;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (isGameOver)
        {
            timer += Time.deltaTime;
            unconciusScreen.SetActive(true);
            player.transform.position = startPos.position;
            player.GetComponent<PlayerMovement>().enabled = false;
            pauseMenu.GetComponent<PAUSEMENU>().enabled = false;
            if(timer > 5f)
            {
                unconciusScreen.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
                pauseMenu.GetComponent<PAUSEMENU>().enabled = true;
            }

        }
    }

    public static void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            isGameOver = true;
        }
    }
}
