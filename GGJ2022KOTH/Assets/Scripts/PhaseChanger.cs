using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChanger : MonoBehaviour
{
    public GameObject player;
    public GameObject cat;
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
        if (player.tag == "Alive" || player.tag == "Dead")
        {
            cat.SetActive(true);
            godMode.SetActive(false);
        }
        else if (player.tag == "God")
        {
            cat.SetActive(false);
            godMode.SetActive(true);
        }
    }

}
