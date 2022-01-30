using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public float speed = 5;
    private Vector2 movementInput;
    public float Score = 0;
    public bool isDefeated = false;
    private void Update()
    {
        PlayerMovement();
        PlayerDefeated();

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
            //Score += Time.deltaTime;
            //Debug.Log(Mathf.Round(Score));
        }
    }
    void PlayerDefeated()
    {

        if (isDefeated)
        {
            speed = 0;
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = respawnPoint.position;
        speed = 5f;
        isDefeated = false;
    }
}
