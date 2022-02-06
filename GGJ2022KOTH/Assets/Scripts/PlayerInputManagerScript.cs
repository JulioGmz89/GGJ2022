using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInputManagerScript : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] scoreTextUI;
    public Text[] playerScoreText;

    public List<GameObject> players = new List<GameObject>();
    public List<float> playerScore = new List<float>();

    public Text winText;
    public GameObject playerWinText;
    public GameObject returnButton;
    private MatchConfig matchConfig;

    void Start()
    {
        matchConfig = gameObject.GetComponent<MatchConfig>();
    }
    void Awake()
    {

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestMove")
        {
            matchConfig.MatchMaking();

            for (int i = 0; i < players.Count; i++)
            {
                DontDestroyOnLoad(players[i]);
                DontDestroyOnLoad(scoreTextUI[i]);
                players[i].transform.position = spawnLocations[i].position;
            }
        }
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput.gameObject);
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;


        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnLocations[playerInput.playerIndex].position;

        if (playerInput.playerIndex == 0)
        {
            scoreTextUI[playerInput.playerIndex].SetActive(true);
        }
        else if (playerInput.playerIndex == 1)
        {
            scoreTextUI[playerInput.playerIndex].SetActive(true);
        }
        else if (playerInput.playerIndex == 2)
        {
            scoreTextUI[playerInput.playerIndex].SetActive(true);
        }
        else if (playerInput.playerIndex == 3)
        {
            scoreTextUI[playerInput.playerIndex].SetActive(true);
        }

    }


    void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playerScoreText[i].text = players[i].GetComponent<PlayerDetails>().score.ToString("0");
            playerScore[i] = players[i].GetComponent<PlayerDetails>().score;
        }

        Debug.Log(players.Count);
    }

    public void returnSpawn()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].tag != "God")
            {

                Vector3 startPos = spawnLocations[i].position;
                players[i].transform.position = startPos;
            }
        }
    }
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
