using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReticleController : MonoBehaviour
{
    public float speed;
    private Vector2 movementInput;
    Vector3 retPos;

    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime, Space.World);
        retPos = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (retPos.x < -1)
        {
            gameObject.transform.position = new Vector3(-0.9f, retPos.y, retPos.z);
        }
        else if (retPos.x > 26)
        {
            gameObject.transform.position = new Vector3(25.9f, retPos.y, retPos.z);
        }
        else if (retPos.z < -7)
        {
            gameObject.transform.position = new Vector3(retPos.x, retPos.y, -6.9f);
        }
        else if (retPos.z > 7)
        {
            gameObject.transform.position = new Vector3(retPos.x, retPos.y, 6.9f);
        }
    }

    public void AimReticle(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
