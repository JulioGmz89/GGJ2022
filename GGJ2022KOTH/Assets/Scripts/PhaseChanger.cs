using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChanger : MonoBehaviour
{
    public GameObject player;
    public GameObject alive;
    public GameObject dead;
    public GameObject godMode;

    int RandN;

    void Awake()
    {
        RandN = Random.Range(1, 50);
        if (RandN < 25)
        {
            player.tag = "Alive";
        }
        else if (RandN > 25)
        {
            player.tag = "Dead";
        }
    }
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6, true);
    }

    void Update()
    {
        if (player.tag == "Alive")
        {
            alive.SetActive(true);
            dead.SetActive(false);
            godMode.SetActive(false);
        }
        else if (player.tag == "Dead")
        {
            alive.SetActive(false);
            dead.SetActive(true);
            godMode.SetActive(false);
        }
        else if (player.tag == "God")
        {
            alive.SetActive(false);
            dead.SetActive(false);
            godMode.SetActive(true);
        }
    }
}
