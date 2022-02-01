using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMainGame : MonoBehaviour
{
    public GameObject playerInput;
    private PlayerInputManagerScript pim;

    public int numberOfPlayers;

    void Start()
    {
        pim = playerInput.GetComponent<PlayerInputManagerScript>();
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
            SceneManager.LoadScene(1);
        }
    }
}
