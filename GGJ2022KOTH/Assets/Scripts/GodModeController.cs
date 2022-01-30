using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeController : MonoBehaviour
{
    [SerializeField]
    private GameObject rayPrefab;
    [SerializeField]
    private Transform firePoint;
    public GameObject reticle;
    public Vector3 newPos;

    private float rayCooldown = 3f;

    private void Update()
    {
        Vector3 godPos = gameObject.transform.position;
        Vector3 relativePos = reticle.transform.position - transform.position;
        newPos = new Vector3(relativePos.x, 0, relativePos.z);
        Quaternion rotation = Quaternion.LookRotation(newPos, Vector3.up);
        transform.rotation = rotation;

        //AUTO SHOOT

        if (Mathf.Round(rayCooldown) > 0)
        {
            rayCooldown -= Time.deltaTime;
        }
        if (Mathf.Round(rayCooldown) == 0)
        {
            CanShoot();
        }

    }

    //MANUAL SHOOT

    // public void OnShoot(InputAction.CallbackContext ctx)
    // {
    //     if (ctx.action.triggered)
    //     {
    //         if (!canShoot) return;
    //         GameObject ray = Instantiate(rayPrefab, firePoint.position, firePoint.rotation);
    //         ray.SetActive(true);
    //         StartCoroutine(CanShoot());
    //     }
    // }

    void CanShoot()
    {
        GameObject ray = Instantiate(rayPrefab, firePoint.position, firePoint.rotation);
        ray.SetActive(true);
        rayCooldown = 3f;
    }
}
