using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReticleController : MonoBehaviour
{
    public float speed = 25;
    private Vector2 movementInput;

    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime, Space.World);
    }

    public void AimReticle(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
