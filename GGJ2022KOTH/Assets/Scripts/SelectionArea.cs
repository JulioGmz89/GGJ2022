using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionArea : MonoBehaviour
{
    public bool playerOnMap;
    public bool playerOnGameMode;
    public GameObject gameModeConfig;
    public int mapSelectionIndex;
    public int gameSelectionIndex;
    public int timeIndex;
    public int scoreIndex;
    public Material Material1;
    public Material Material2;
    private static GameObject self;

    private Controls controls;

    private MatchConfig matchConfig;

    public float[] timeOptions;
    public int[] scoreOptions;

    public bool timeConfig;
    public bool scoreConfig;

    private void Awake()
    {
        controls = new Controls();
        self = gameObject;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {
        matchConfig = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<MatchConfig>();
        controls.Gameplay.Select.performed += _ => PlayerSelect();
    }
    public void PlayerSelect()
    {

        if (playerOnMap)
        {
            if (mapSelectionIndex == 2)
            {
                mapSelectionIndex = 0;
            }
            else
            {
                mapSelectionIndex += 1;
            }
        }
        else if (playerOnGameMode)
        {
            if (gameSelectionIndex == 1)
            {
                gameModeConfig.transform.GetChild(0).gameObject.SetActive(true);
                gameModeConfig.transform.GetChild(1).gameObject.SetActive(false);
                gameSelectionIndex = 0;
            }
            else
            {
                gameModeConfig.transform.GetChild(1).gameObject.SetActive(true);
                gameModeConfig.transform.GetChild(0).gameObject.SetActive(false);
                gameSelectionIndex += 1;
            }
        }
        else if (timeConfig)
        {
            if (timeIndex == timeOptions.Length)
            {
                timeIndex = 0;
            }
            else
            {
                timeIndex += 1;
            }
            matchConfig.TimeConfig();
        }
        else if (scoreConfig)
        {
            if (scoreIndex == scoreOptions.Length)
            {
                scoreIndex = 0;
            }
            else
            {
                scoreIndex += 1;
            }
            matchConfig.ScoreConfig();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dead" || other.tag == "Alive")
        {
            if (gameObject.tag == "MapSelection")
            {
                playerOnMap = true;
            }
            else if (gameObject.tag == "GameModeSelection")
            {
                playerOnGameMode = true;
            }
            else if (gameObject.tag == "TimeConfig")
            {
                timeConfig = true;
            }
            else if (gameObject.tag == "ScoreConfig")
            {
                scoreConfig = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dead" || other.tag == "Alive")
        {
            if (gameObject.tag == "MapSelection")
            {
                playerOnMap = false;
            }
            else if (gameObject.tag == "GameModeSelection")
            {
                playerOnGameMode = false;
            }
            else if (gameObject.tag == "TimeConfig")
            {
                timeConfig = false;
            }
            else if (gameObject.tag == "ScoreConfig")
            {
                scoreConfig = false;
            }
        }
    }
}
