using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;



public class GodModeController : MonoBehaviour
{
    [SerializeField]
    private GameObject rayPrefab;
    [SerializeField]
    private Transform firePoint;
    Cinemachine.CinemachineImpulseSource source;
    public GameObject reticle;
    private Vector2 movementInput;
    Vector3 newPos;
    public GameObject player;
    float score;
    public AudioSource sound;
    private float rayCooldown = 2.5f;

    public float HighRumble;
    public float LowRumble;
    public float StopRumble;
    public GameObject throneDecoy;
    public GameObject godDecoy;
    public GameObject rayDecoy;
    public Animator throneAnimator;
    public GameObject godMainMesh;
    public GameObject throneMainMesh;

    private void Start()
    {
        rayCooldown = 2.5f;
        //sound.Play();
        //sound.loop = true;
    }
    private void Update()
    {

        // Vector3 relativePos = reticle.transform.position - transform.position;
        // newPos = new Vector3(relativePos.x, 0, relativePos.z);
        // Quaternion rotation = Quaternion.LookRotation(newPos, Vector3.up);
        // transform.rotation = rotation;

        //AUTO SHOOT

        if (Mathf.Round(rayCooldown) > 0)
        {
            rayCooldown -= Time.deltaTime;

        }
        if (Mathf.Round(rayCooldown) == 0)
        {
            StartCoroutine(CanShoot());

        }

        //score = player.GetComponent<PlayerDetails>().score;

        //if (Mathf.Round(score) >= 100)
        //{
        //    sound.loop = false;
        //}
        //if(Mathf.Round(rayCooldown) == 1)
        //{
        //    Gamepad.current.SetMotorSpeeds(0f, 0f);
        //}

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

    IEnumerator CanShoot()
    {
        rayCooldown = 5.2f;
        //Tiempo entre rayos
        yield return new WaitForSeconds(0.9f);
        sound.Play();
        yield return new WaitForSeconds(0.1f);
        //Empieza la animacion de disparo
        godDecoy.SetActive(true);
        throneDecoy.SetActive(true);
        rayDecoy.SetActive(true);
        godMainMesh.SetActive(false);
        throneAnimator.SetBool("Fire", true);
        //Timer en lo que castea el disparo
        yield return new WaitForSeconds(2f);
        //Disparo
        //GameObject ray = Instantiate(rayPrefab, firePoint.position, firePoint.rotation);
        //ray.SetActive(true);
        //Bug de screen Shake muy largo
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse(Camera.main.transform.forward);
        Gamepad.current.SetMotorSpeeds(LowRumble, HighRumble);
        rayDecoy.GetComponent<Collider>().enabled = true;
        player.GetComponent<PlayerController>().speed = 0;
        reticle.GetComponent<ReticleController>().speed = 0;
        Vector3 relativePos = reticle.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        throneMainMesh.transform.rotation = rotation;
        yield return new WaitForSeconds(StopRumble);
        Gamepad.current.SetMotorSpeeds(0, 0);
        //Tiempo para que termine la animacion
        yield return new WaitForSeconds(1.25f);
        player.GetComponent<PlayerController>().speed = 5;
        rayDecoy.GetComponent<Collider>().enabled = false;
        reticle.GetComponent<ReticleController>().speed = 15;
        throneMainMesh.transform.rotation = Quaternion.Euler(0, -90, 0);
        //Fin de la animacion
        godDecoy.SetActive(false);
        throneAnimator.SetBool("Fire", false);
        throneDecoy.SetActive(false);
        godMainMesh.SetActive(true);
        rayDecoy.SetActive(false);
        //yield return new WaitForSeconds(1.5f);

    }
}
