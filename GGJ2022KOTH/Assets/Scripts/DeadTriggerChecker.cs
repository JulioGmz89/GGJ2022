using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTriggerChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Alive")
        {
            Debug.Log("Player is in alive state");
        }
        else if (other.tag == "Dead")
        {
            Debug.Log("Player is in dead state");
            //Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
