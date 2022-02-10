using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMainGame : MonoBehaviour
{
    private PlayerInputManagerScript pim;
    private MatchConfig matchConfig;

    public int numberOfPlayers;

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

    void Update()
    {
        Debug.Log(pim.players.Count);
        if (numberOfPlayers != 0 && numberOfPlayers == pim.players.Count)
        {
            matchConfig.MatchMaking();
            SceneManager.LoadScene(1);
        }
    }
}
