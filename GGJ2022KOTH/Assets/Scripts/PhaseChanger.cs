using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChanger : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.tag = "Alive";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject.tag == "Alive")
        {
            Debug.Log("Player is in Alive state");
        }
        else
        {
            Debug.Log("Player is in Dead state");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (transform.gameObject.tag == "Alive")
            {
                transform.gameObject.tag = "Dead";
            }
            else if (transform.gameObject.tag == "Dead")
            {
                transform.gameObject.tag = "Alive";
            }
        }
    }

}
