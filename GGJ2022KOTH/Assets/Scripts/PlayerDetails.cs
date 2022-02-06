using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public int playerID;
    public Vector3 startPos;
    public float score = 0;

    void Start()
    {
        transform.position = startPos;
    }
    void Update()
    {
        if (gameObject.tag == "God")
        {
            score += Time.deltaTime;
        }
    }
}
