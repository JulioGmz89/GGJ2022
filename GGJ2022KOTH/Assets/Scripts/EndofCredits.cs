using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofCredits : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Credits")
        {
            StartCoroutine(EndofTime());
        }
    }
    IEnumerator EndofTime()
    {
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene(0);
    }
}
