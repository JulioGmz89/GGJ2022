using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MatchConfig : MonoBehaviour
{
    public float matchTime;
    public int matchScore;
    private SelectionArea mapSelection;
    private SelectionArea gameSelection;
    public GameObject mapSelectionArea;
    public GameObject gameModeSelectionArea;

    private PlayerInputManagerScript pim;
    public Text winText;
    public GameObject playerWinText;
    public GameObject returnButton;
    public bool matchConfigA = false;
    public bool matchConfigB = false;

    public Text timerText;
    public GameObject timerUI;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        mapSelection = mapSelectionArea.GetComponent<SelectionArea>();
        gameSelection = gameModeSelectionArea.GetComponent<SelectionArea>();
        pim = gameObject.GetComponent<PlayerInputManagerScript>();
    }
    void Update()
    {
        if (matchConfigA)
        {
            timerUI.SetActive(true);
            timerText.text = matchTime.ToString("0");
            Debug.Log(" Empezo el timer");
            float maxScore = pim.playerScore[0];
            int playerIndex = 0;
            if (Mathf.Round(matchTime) > 0)
            {
                matchTime -= Time.deltaTime;

            }
            if (Mathf.Round(matchTime) == 0)
            {
                for (int i = 0; i < pim.playerScore.Count; i++)
                {
                    if (pim.playerScore[i] > maxScore)
                    {
                        maxScore = pim.playerScore[i];
                        playerIndex = i;
                    }
                }
                PlayerWin(playerIndex + 1);
            }
        }
        if (matchConfigB)
        {
            for (int i = 0; i < pim.players.Count; i++)
            {
                if (Mathf.Round(pim.players[i].GetComponent<PlayerDetails>().score) == matchScore)
                {
                    PlayerWin(i + 1);
                }
            }
        }

    }

    public void MatchMaking()
    {
        if (gameSelection.gameSelectionIndex == 0)
        {
            matchConfigA = true;
            Debug.Log("GameModeSelection: 1");
        }
        else if (gameSelection.gameSelectionIndex == 1)
        {
            matchConfigB = true;
            Debug.Log("GameModeSelection: 2");
        }
    }
    public void PlayerWin(int playerNumber)
    {
        playerWinText.SetActive(true);
        winText.text = "Player " + playerNumber + " wins";
        Time.timeScale = 0f;
        returnButton.SetActive(true);
    }

}
