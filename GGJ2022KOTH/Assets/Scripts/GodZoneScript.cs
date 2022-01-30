using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodZoneScript : MonoBehaviour
{
    private GameObject currentGod;
    public GameObject playerInput;
    private PlayerInputManagerScript pim;
    void Start()
    {
        pim = playerInput.GetComponent<PlayerInputManagerScript>();
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
            }
        }
    }
}
