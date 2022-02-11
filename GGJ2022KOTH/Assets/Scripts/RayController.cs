using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public GameObject reticle;
    public AudioSource sound;
    private Vector3 newPos;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(6, 7, false);
    }

    private void Start()
    {
        //StartCoroutine(DestroyRayAfterTime());
    }

    void Update()
    {
        Vector3 relativePos = reticle.transform.position - transform.position;
        newPos = new Vector3(relativePos.x, 0, relativePos.z);
        Quaternion rotation = Quaternion.LookRotation(newPos, Vector3.up);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Alive")
        {
            Debug.Log("Alive player hit");
            other.tag = "Dead";
            other.transform.GetChild(1).transform.GetChild(0).GetComponent<Animator>().Play("AliveToDead");
            other.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Swap");
            PAudio();
            Physics.IgnoreLayerCollision(6, 7);
        }
        else if (other.tag == "Dead")
        {
            Debug.Log("Dead player hit");
            other.tag = "Alive";
            other.transform.GetChild(1).transform.GetChild(0).GetComponent<Animator>().Play("DeadToAlive");
            other.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Swap");
            PAudio();
            Physics.IgnoreLayerCollision(6, 7);
        }
    }
    public void PAudio()
    {
        sound.Play();
    }

}
