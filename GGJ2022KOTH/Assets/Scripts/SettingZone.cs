using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingZone : MonoBehaviour
{
    private PlayerInputManagerScript pim;
    public static bool GameIsPaused = false;
    private MatchConfig matchConfig;

    public int numberOfPlayers;
    public GameObject settingUI;
    public GameObject backB;
    public GameObject Slide;

    void Start()
    {
        pim = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerInputManagerScript>();
        matchConfig = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<MatchConfig>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dead" || other.tag == "Alive")
        {
            numberOfPlayers++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dead" || other.tag == "Alive")
        {
            numberOfPlayers--;
        }
    }
    public void returnSpawn()
    {
        for (int i = 0; i < pim.players.Count; i++)
        {
            if (pim.players[i].tag != "God")
            {

                Vector3 startPos = pim.spawnLocations[i].position;
                pim.players[i].transform.position = startPos;
            }
        }
    }
    void Update()
    {
        if (numberOfPlayers != 0 && numberOfPlayers == pim.players.Count)
        {
            GameIsPaused = true;
            returnSpawn();
            Pause();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        settingUI.SetActive(false);
        backB.SetActive(false);
        Slide.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0;
        settingUI.SetActive(true);
        backB.SetActive(true);
        Slide.SetActive(true);
    }
}
