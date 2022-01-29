using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public float speed = 5;
    private Vector2 movementInput;
    public bool isDefeated = false;

    private void Update()
    {
        if (player.tag == "Alive" || player.tag == "Dead")
        {
            transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        }

        else if (player.tag == "God")
        {
            transform.Translate(new Vector3(0, 0, movementInput.y) * speed * Time.deltaTime, Space.World);
        }


        if (isDefeated)
        {
            speed = 0;
            StartCoroutine(Respawn());
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = respawnPoint.position;
        speed = 5f;
        isDefeated = false;
    }
}
