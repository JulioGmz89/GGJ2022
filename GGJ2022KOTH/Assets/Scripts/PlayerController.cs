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
    public Animator alivePlayerAnim;
    public Animator deadPlayerAnim;
    public bool playerSelectionInput = false;
    void Start()
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(gameObject);
    }
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
            transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime, Space.World);


            Vector3 lookDirection = new Vector3(movementInput.x, 0, movementInput.y);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            if (movementInput.x != 0 || movementInput.y != 0)
            {

                transform.rotation = Quaternion.RotateTowards(lookRotation, transform.rotation, 5 * Time.deltaTime);
                if (player.tag == "Alive")
                {
                    alivePlayerAnim.SetBool("isRunning", true);
                }
                else if (player.tag == "Dead")
                {
                    deadPlayerAnim.SetBool("isRunning", true);
                }

            }
            else
            {
                alivePlayerAnim.SetBool("isRunning", false);
                deadPlayerAnim.SetBool("isRunning", false);
            }
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
        else if (player.tag == "Alive" || player.tag == "Dead")
        {
            if (other.tag == "FastTile")
            {
                speed = 10;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player.tag == "Alive" || player.tag == "Dead")
        {
            if (other.tag == "FastTile")
            {
                speed = 5;
            }
        }
    }
    void PlayerDefeated()
    {
        gameObject.transform.position = respawnPoints[Random.Range(0, respawnPoints.Length)].position;
        isDefeated = false;
    }



}
