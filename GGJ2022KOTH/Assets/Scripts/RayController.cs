using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public AudioSource sound;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(6, 7, false);
    }

    private void Start()
    {
        StartCoroutine(DestroyRayAfterTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Alive")
        {
            Debug.Log("Alive player hit");
            other.tag = "Dead";
            other.transform.GetChild(1).transform.GetChild(0).GetComponent<Animator>().Play("AliveToDead");
            PAudio();
            Physics.IgnoreLayerCollision(6, 7);
        }
        else if (other.tag == "Dead")
        {
            Debug.Log("Dead player hit");
            other.tag = "Alive";
            other.transform.GetChild(1).transform.GetChild(0).GetComponent<Animator>().Play("DeadToAlive");
            PAudio();
            Physics.IgnoreLayerCollision(6, 7);
        }
    }

    IEnumerator DestroyRayAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public void PAudio()
    {
        sound.Play();
    }

}
