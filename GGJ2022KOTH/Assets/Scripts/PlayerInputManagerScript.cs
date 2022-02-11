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
    public GameObject[] pressButtonUI;
    public Text[] playerScoreText;

    public List<GameObject> players = new List<GameObject>();
    public List<float> playerScore = new List<float>();

    public Text winText;
    public GameObject playerWinText;
    public GameObject returnButton;
    private MatchConfig matchConfig;
    private Outline outline;

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
            for (int i = 0; i < players.Count; i++)
            {
                DontDestroyOnLoad(players[i]);
                DontDestroyOnLoad(scoreTextUI[i]);
                players[i].transform.position = spawnLocations[i].position;
            }
            for (int i = 0; i < pressButtonUI.Length; i++)
            {
                pressButtonUI[i].SetActive(false);
            }
        }
        else if (scene.name == "TestLobby")
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].tag == "God")
                {
                    int randNum = Random.Range(1, 50);
                    if (randNum < 25)
                    {
                        players[i].tag = "Alive";
                    }
                    else if (randNum > 25)
                    {
                        players[i].tag = "Dead";
                    }
                }
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
            playerInput.gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Outline>().OutlineColor = new Color(255f / 255f, 43f / 255f, 43f / 255f);
            scoreTextUI[playerInput.playerIndex].SetActive(true);
            pressButtonUI[playerInput.playerIndex].SetActive(false);
        }
        else if (playerInput.playerIndex == 1)
        {
            playerInput.gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Outline>().OutlineColor = new Color(24f / 255f, 196f / 255f, 250f / 255f);
            scoreTextUI[playerInput.playerIndex].SetActive(true);
            pressButtonUI[playerInput.playerIndex].SetActive(false);
        }
        else if (playerInput.playerIndex == 2)
        {
            playerInput.gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Outline>().OutlineColor = new Color(224f / 255f, 130f / 255f, 60f / 255f);
            scoreTextUI[playerInput.playerIndex].SetActive(true);
            pressButtonUI[playerInput.playerIndex].SetActive(false);
        }
        else if (playerInput.playerIndex == 3)
        {
            playerInput.gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Outline>().OutlineColor = new Color(249f / 255f, 42f / 255f, 6f / 255f);
            scoreTextUI[playerInput.playerIndex].SetActive(true);
            pressButtonUI[playerInput.playerIndex].SetActive(false);
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
                players[i].GetComponent<PlayerController>().speed = 5;
                players[i].GetComponent<PlayerController>().StartCoroutine("CatsTextures");

            }
        }
    }
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
