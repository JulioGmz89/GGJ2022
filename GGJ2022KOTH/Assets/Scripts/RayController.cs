using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyRayAfterTime());
    }

    IEnumerator DestroyRayAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }
}
