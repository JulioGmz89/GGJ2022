using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchConfig : MonoBehaviour
{
    public float matchTime;
    public int matchScore;
    private SelectionArea gameSelection;
    private SelectionArea timeConfig;
    private SelectionArea scoreConfig;
    private PlayerInputManagerScript pim;
    public Text winText;
    public GameObject playerWinText;
    public GameObject returnButton;
    public bool matchConfigA = false;
    public bool matchConfigB = false;
    public AudioSource sound;
    public Text timerText;
    public GameObject timerUI;

    public Text matchText;
    public GameObject matchUI;

    public GameObject score50, score100, score150;
    public GameObject time60, time90, time120, time150;

    public GameObject winScreen1, winScreen2, winScreen3, winScreen4;

    private void Start()
    {
        pim = gameObject.GetComponent<PlayerInputManagerScript>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestLobby")
        {
            Time.timeScale = 1f;
            timerUI.SetActive(false);
            matchUI.SetActive(false);
            returnButton.SetActive(false);
            playerWinText.SetActive(false);
            winScreen1.SetActive(false);
            winScreen2.SetActive(false);
            winScreen3.SetActive(false);
            winScreen4.SetActive(false);
            matchTime = 50;
            matchConfigA = false;
            matchConfigB = false;
            pim.returnSpawn();
        }
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
            matchUI.SetActive(true);
            matchText.text = matchScore.ToString("0");
            for (int i = 0; i < pim.players.Count; i++)
            {
                if (Mathf.Round(pim.players[i].GetComponent<PlayerDetails>().score) == matchScore)
                {
                    PlayerWin(i + 1);
                }
            }
        }
        if (matchScore == 50)
        {
            score50.SetActive(true);
            score100.SetActive(false);
            score150.SetActive(false);
        }
        else if (matchScore == 100)
        {
            score50.SetActive(false);
            score100.SetActive(true);
            score150.SetActive(false);
        }
        else if (matchScore == 150)
        {
            score50.SetActive(false);
            score100.SetActive(false);
            score150.SetActive(true);
        }

        if (matchTime == 60)
        {
            time60.SetActive(true);
            time90.SetActive(false);
            time120.SetActive(false);
            time150.SetActive(false);
        }
        else if (matchTime == 90)
        {
            time60.SetActive(false);
            time90.SetActive(true);
            time120.SetActive(false);
            time150.SetActive(false);
        }
        else if (matchTime == 120)
        {
            time60.SetActive(false);
            time90.SetActive(false);
            time120.SetActive(true);
            time150.SetActive(false);
        }
        else if (matchTime == 150)
        {
            time60.SetActive(false);
            time90.SetActive(false);
            time120.SetActive(false);
            time150.SetActive(true);
        }


    }
    public void TimeConfig()
    {
        timeConfig = GameObject.FindGameObjectWithTag("TimeConfig").GetComponent<SelectionArea>();
        if (timeConfig.timeIndex == 0)
        {
            matchTime = timeConfig.timeOptions[timeConfig.timeIndex];
        }
        else if (timeConfig.timeIndex == 1)
        {
            matchTime = timeConfig.timeOptions[timeConfig.timeIndex];
        }
        else if (timeConfig.timeIndex == 2)
        {
            matchTime = timeConfig.timeOptions[timeConfig.timeIndex];
        }
        else if (timeConfig.timeIndex == 3)
        {
            matchTime = timeConfig.timeOptions[timeConfig.timeIndex];
        }
    }

    public void ScoreConfig()
    {
        scoreConfig = GameObject.FindGameObjectWithTag("ScoreConfig").GetComponent<SelectionArea>();

        if (scoreConfig.scoreIndex == 0)
        {
            matchScore = scoreConfig.scoreOptions[scoreConfig.scoreIndex];
        }
        else if (scoreConfig.scoreIndex == 1)
        {
            matchScore = scoreConfig.scoreOptions[scoreConfig.scoreIndex];
        }
        else if (scoreConfig.scoreIndex == 2)
        {
            matchScore = scoreConfig.scoreOptions[scoreConfig.scoreIndex];
        }
    }

    public void MatchMaking()
    {
        gameSelection = GameObject.FindGameObjectWithTag("GameModeSelection").GetComponent<SelectionArea>();
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
        if (playerNumber == 1)
        {
            winScreen1.SetActive(true);
        }
        else if (playerNumber == 2)
        {
            winScreen2.SetActive(true);
        }
        else if (playerNumber == 3)
        {
            winScreen3.SetActive(true);
        }
        else if (playerNumber == 4)
        {
            winScreen4.SetActive(true);
        }
        winText.text = "Player " + playerNumber + " wins";
        Time.timeScale = 0f;
        returnButton.SetActive(true);
        sound.Play();
    }

}
