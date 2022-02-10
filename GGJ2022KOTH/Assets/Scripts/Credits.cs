using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject playerInput;
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
            SceneManager.LoadScene(2);
            returnSpawn();
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
}
