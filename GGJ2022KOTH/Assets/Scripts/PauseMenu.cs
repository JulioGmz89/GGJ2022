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
    public GameObject Slide;
    public GameObject pyramid;
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
        Slide.SetActive(false);
        pyramid.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        resumeB.SetActive(true);
        mainMenuB.SetActive(true);
        pyramid.SetActive(true);
        Slide.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void Return()
    {
        Resume();
        timerUI.SetActive(false);
        timerText.text = "0";
        SceneManager.LoadScene(0);
        matchConfig.matchConfigA = false;
        matchConfig.matchConfigB = false;
    }
}
