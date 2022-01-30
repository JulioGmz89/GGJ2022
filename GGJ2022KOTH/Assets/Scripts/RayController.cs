using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyRayAfterTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Alive")
        {
            Debug.Log("Alive player hit");
            other.tag = "Dead";
        }
        else if(other.tag == "Dead")
        {
            Debug.Log("Dead player hit");
            other.tag = "Alive";
        }
    }

    IEnumerator DestroyRayAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
