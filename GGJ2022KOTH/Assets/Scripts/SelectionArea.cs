using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionArea : MonoBehaviour
{
    public bool playerOnMap;
    public bool playerOnGameMode;
    public int mapSelectionIndex;
    public int gameSelectionIndex;
    public Material Material1;
    public Material Material2;
    private static GameObject self;

    private Controls controls;

    private MatchConfig matchConfig;
    public GameObject playerInput;

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
        matchConfig = playerInput.GetComponent<MatchConfig>();
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
                gameSelectionIndex = 0;
            }
            else
            {
                gameSelectionIndex += 1;
            }
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
        }
    }
}
