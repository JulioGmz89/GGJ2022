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

    private void Start()
    {
        rayCooldown = 2.5f;
        sound.Play();
        //sound.loop = true;
    }
    private void Update()
    {

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
        GameObject ray = Instantiate(rayPrefab, firePoint.position, firePoint.rotation);
        ray.SetActive(true);
        rayCooldown = 4.5f;
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse(Camera.main.transform.forward);
        Gamepad.current.SetMotorSpeeds(LowRumble, HighRumble);
        player.GetComponent<PlayerController>().speed = 0;
        reticle.GetComponent<ReticleController>().speed = 0;
        yield return new WaitForSeconds(StopRumble);
        player.GetComponent<PlayerController>().speed = 5;
        reticle.GetComponent<ReticleController>().speed = 15;
        Gamepad.current.SetMotorSpeeds(0, 0);
        yield return new WaitForSeconds(1.5f);
        sound.Play();
    }
}
