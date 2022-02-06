using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;


public class Rumble : MonoBehaviour
{
    public float HighRumble;
    public float LowRumble;
    public float StopRumble;
    private void Start()
    {
        StartCoroutine(Rumbling());
    }
    IEnumerator Rumbling()
    {
        Gamepad.current.SetMotorSpeeds(LowRumble, HighRumble);
        yield return new WaitForSeconds(StopRumble);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
    
}
