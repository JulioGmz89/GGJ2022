using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodZoneScript : MonoBehaviour
{
    private GameObject currentGod;
    private PlayerInputManagerScript pim;
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    void Start()
    {
        pim = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerInputManagerScript>();
        map1.SetActive(true);
        map2.SetActive(false);
        map3.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dead" || other.tag == "Alive")
        {
            if (currentGod == null)
            {
                other.transform.position = new Vector3(25, 0, 0);
                other.tag = "God";
                currentGod = other.gameObject;
                pim.returnSpawn();
                ChangeMap();
            }
            else
            {
                int RandN = Random.Range(1, 50);
                if (RandN < 25)
                {
                    currentGod.tag = "Alive";

                }
                else if (RandN > 25)
                {
                    currentGod.tag = "Dead";
                }

                other.transform.position = new Vector3(25, 0, 0);
                other.tag = "God";
                currentGod = other.gameObject;
                pim.returnSpawn();
                ChangeMap();
            }
        }
    }

    void ChangeMap()
    {
        int randNum = Random.Range(1, 4);
        if (randNum == 1)
        {
            map1.SetActive(true);
            map2.SetActive(false);
            map3.SetActive(false);
        }
        else if (randNum == 2)
        {
            map1.SetActive(false);
            map2.SetActive(true);
            map3.SetActive(false);
        }
        else if (randNum == 3)
        {
            map1.SetActive(false);
            map2.SetActive(false);
            map3.SetActive(true);
        }
    }

}
