using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetails : MonoBehaviour
{
    public int playerID;
    public Vector3 startPos;
    public float score = 0;

    void Start()
    {
        score = 0;
        transform.position = startPos;
    }
    void Update()
    {
        if (gameObject.tag == "God")
        {
            score += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "TestLobby")
        {

            score = 0;

        }
    }
}
