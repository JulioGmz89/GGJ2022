using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject resumeB;
    public GameObject mainMenuB;
    public PlayerInputManagerScript playerManager;
    private MatchConfig matchConfig;
    public GameObject settingB;
    public GameObject settingUI;
    public GameObject backB;
    public GameObject Slide;

    public Text timerText;
    public GameObject timerUI;
    public int num;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerInputManagerScript>();
        matchConfig = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<MatchConfig>();
    }
    private void Awake()
    {
        num = FindObjectsOfType<DontDestroy>().Length;
        if (num != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
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
        Time.timeScale = 1;
        settingB.SetActive(false);
        settingUI.SetActive(false);
        backB.SetActive(false);
        Slide.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        resumeB.SetActive(true);
        mainMenuB.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        settingB.SetActive(true);
    }
    void Return()
    {
        Resume();
        timerUI.SetActive(false);
        timerText.text = "0";
        SceneManager.LoadScene(0);
        matchConfig.matchConfigA = false;
        matchConfig.matchConfigB = false;
    }
    public void Settings()
    {
        resumeB.SetActive(false);
        pauseMenuUI.SetActive(false);
        mainMenuB.SetActive(false);
        settingB.SetActive(false);
        settingUI.SetActive(true);
        backB.SetActive(true);
        Slide.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backB);
    }

}
