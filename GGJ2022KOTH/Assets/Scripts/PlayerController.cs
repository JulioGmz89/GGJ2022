using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Transform[] respawnPoints;
    public float speed = 5;
    private Vector2 movementInput;
    public float Score = 0;
    public bool isDefeated = false;
    private void Update()
    {
        PlayerMovement();

        if (isDefeated)
        {
            PlayerDefeated();
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    void PlayerMovement()
    {
        if (player.tag == "Alive" || player.tag == "Dead")
        {
            transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        }

        else if (player.tag == "God")
        {
            transform.Translate(new Vector3(0, 0, movementInput.y) * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (player.tag == "Alive" && other.tag == "DeadZone" && isDefeated == false)
        {
            isDefeated = true;
        }
        else if (player.tag == "Dead" && other.tag == "AliveZone" && isDefeated == false)
        {
            isDefeated = true;

        }
    }
    void PlayerDefeated()
    {
        gameObject.transform.position = respawnPoints[Random.Range(0, respawnPoints.Length)].position;
        isDefeated = false;
    }
}
