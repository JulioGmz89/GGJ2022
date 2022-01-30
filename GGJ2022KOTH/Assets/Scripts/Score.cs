using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private PlayerController controller;
    private GameObject player;

    void Start()
    {

    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("God");
        controller = player.GetComponent<PlayerController>();
        Debug.Log(controller.Score);
        scoreText.text = controller.Score.ToString();
    }
}
