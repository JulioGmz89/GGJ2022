using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputManagerScript : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] scoreText;
    public Text[] playerScore;

    private List<GameObject> players = new List<GameObject>();


    void Start()
    {

    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput.gameObject);
        Debug.Log("aaa" + playerInput);
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;


        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnLocations[playerInput.playerIndex].position;

        if (playerInput.playerIndex == 0)
        {
            scoreText[playerInput.playerIndex].SetActive(true);
        }
        else if (playerInput.playerIndex == 1)
        {
            scoreText[playerInput.playerIndex].SetActive(true);
        }
        else if (playerInput.playerIndex == 2)
        {
            scoreText[playerInput.playerIndex].SetActive(true);
        }
        else if (playerInput.playerIndex == 3)
        {
            scoreText[playerInput.playerIndex].SetActive(true);
        }

        playerScore[playerInput.playerIndex].text = playerInput.gameObject.GetComponent<PlayerDetails>().score.ToString();
    }


    void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerScore[i].text = players[i].GetComponent<PlayerDetails>().score.ToString("0");
        }


    }
}
