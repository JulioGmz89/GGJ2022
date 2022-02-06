using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject resumeB;
    public GameObject mainMenuB;
    public GameObject playerManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire3"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        resumeB.SetActive(false);
        pauseMenuUI.SetActive(false);
        mainMenuB.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        resumeB.SetActive(true);
        mainMenuB.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Return()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        for (int i=0; i < playerManager.GetComponent<PlayerInputManagerScript>().players.Count; i++)
        {
            Destroy(playerManager.GetComponent<PlayerInputManagerScript>().players[i]);
        }
        SceneManager.LoadScene(0);
    }


    /*public PlayerInput playerInput;
    public GameObject pauseMenuPanel;


    public void TogglePause(InputAction.CallbackContext context)
    {
        if (!pauseMenuPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            playerInput.SwitchCurrentActionMap("UI");
            pauseMenuPanel.SetActive(true);
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            Debug.Log("Game Paused");
            //isPaused = true;
        }

        else
        {
            Time.timeScale = 1;
            playerInput.SwitchCurrentActionMap("Gameplay");
            pauseMenuPanel.SetActive(false);
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            Debug.Log("Game Unpaused");

        }

    }*/

}
