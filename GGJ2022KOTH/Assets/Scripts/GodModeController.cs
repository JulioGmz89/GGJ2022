using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GodModeController : MonoBehaviour
{
    [SerializeField]
    private GameObject rayPrefab;
    [SerializeField]
    private Transform firePoint;

    public float speed = 10;
    public GameObject reticle;
    private bool canShoot = true;
    private Vector2 movementInput;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, movementInput.y) * speed * Time.deltaTime, Space.World);

        Vector3 relativePos = reticle.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.action.triggered)
        {
            if (!canShoot) return;
            GameObject ray = Instantiate(rayPrefab, firePoint.position, firePoint.rotation);
            ray.SetActive(true);
            StartCoroutine(CanShoot());
        }
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }
}
