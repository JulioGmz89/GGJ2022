using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Transform[] respawnPoints;
    public AudioSource sound;
    public float speed = 5;
    private Vector2 movementInput;
    public bool isDefeated = false;
    public Animator catAnim;
    public Animator catMeshAnim;
    public GameObject smokePrefab;
    private float timeRemaining = .5f;
    //public Animator deadPlayerAnim;
    public bool playerSelectionInput = false;

    void Start()
    {
        //Time.timeScale = 1;
        DontDestroyOnLoad(gameObject);
        StartCoroutine("CatsTextures");
    }
    private void Update()
    {
        PlayerMovement();

        if (isDefeated)
        {
            StartCoroutine(PlayerDefeated());
        }

        if (Mathf.Round(timeRemaining) > 0)
        {
            timeRemaining -= Time.deltaTime;

        }

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void PlayerMovement()
    {
        if (player.tag == "Alive" || player.tag == "Dead")
        {
            transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime, Space.World);


            Vector3 lookDirection = new Vector3(movementInput.x, 0, movementInput.y);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            if (movementInput.x != 0 || movementInput.y != 0)
            {
                transform.rotation = Quaternion.RotateTowards(lookRotation, transform.rotation, 5 * Time.deltaTime);
                if (Mathf.Round(timeRemaining) == 0)
                {
                    StartCoroutine("DisplaySmoke");

                }

                if (player.tag == "Alive" || player.tag == "Dead")
                {
                    catAnim.SetBool("isRunning", true);
                    if (!sound.isPlaying)
                    {
                        PAudio();
                    }

                }
            }
            else
            {
                catAnim.SetBool("isRunning", false);
            }
        }

        else if (player.tag == "God")
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.Translate(new Vector3(0, 0, movementInput.y) * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
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
            if (other.tag == "SlowTile")
            {
                speed = 2.5f;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (player.tag == "Alive" || player.tag == "Dead")
        {
            if (other.tag == "FastTile" || other.tag == "SlowTile")
            {
                speed = 5;
            }
        }
    }
    IEnumerator PlayerDefeated()
    {
        FindObjectOfType<AudioManager>().Play("Def");
        speed = 0;
        isDefeated = false;
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = respawnPoints[Random.Range(0, respawnPoints.Length)].position;
        speed = 5;

    }
    public void PAudio()
    {
        sound.Play();
    }

    public IEnumerator CatsTextures()
    {
        yield return new WaitForSeconds(0.01f);
        if (player.tag == "Alive")
        {
            catMeshAnim.Play("AliveCat");
        }
        else if (player.tag == "Dead")
        {
            catMeshAnim.Play("DeadCat");
        }
    }

    public IEnumerator DisplaySmoke()
    {
        var temp = Instantiate(smokePrefab, transform.position, transform.rotation);
        timeRemaining = 1f;
        yield return new WaitForSeconds(1f);
        Destroy(temp);
    }
}
