using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Gameplay,
        Pause,
        GameOver,
        LevelUp
    }

    public GameState curState;
    public GameState preState;

    GameObject player;

    [SerializeField] public PlayerStat playerData;

    [Header("UI")]
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject levelUpScreen;
    [SerializeField] public GameObject gameOverScreen;

    [SerializeField] public Text recoveryDisplay;
    [SerializeField] public Text speedDisplay;
    [SerializeField] public Text damageDisplay;
    [SerializeField] public Text growthDisplay;
    [SerializeField] public Text pickupRangeDisplay;
    [SerializeField] public Text fireRateDisplay;
    [SerializeField] public Text fireRangeDisplay;

    [Header("Stop Watch")]
    [SerializeField] public Text stopWatchDisplay;
    [HideInInspector] public float StopWatchTime = 0;
    [HideInInspector] public int minute = 0;
    [HideInInspector] public int sencond = 0;

    private bool isChosingUpgrade;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        player = GameObject.Find("Player");
        disableScr();
    }

    void Update()
    {
        switch (curState)
        {
            case GameState.Gameplay:
                UpdateStopWatch();
                CheckPauseAndResume();
                break;
            case GameState.Pause:
                CheckPauseAndResume();
                break;
            case GameState.GameOver:
                gameOverScreen.SetActive(true);
                break;
            case GameState.LevelUp:
                if (!isChosingUpgrade)
                {
                    isChosingUpgrade = true;
                    Time.timeScale = 0;
                    levelUpScreen.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void PauseGame()
    {
        preState = curState;
        curState = GameState.Pause;

        recoveryDisplay.text = "Regen: " + Math.Round(playerData.currentRecovery, 2).ToString() + "/s";
        speedDisplay.text = "Move Speed: " + Math.Round(playerData.currentSpeed, 2).ToString();
        damageDisplay.text = "Damage Multi: " + Math.Round(playerData.currentDamageMultiplier, 2).ToString();
        growthDisplay.text = "Growth: " + Math.Round(playerData.currentGrowth, 2).ToString();
        pickupRangeDisplay.text = "Pickup Range: " + Math.Round(playerData.currentPickUpRange, 2).ToString();
        fireRateDisplay.text = "Fire Rate: " + Math.Round(FindObjectOfType<WeaponController>().currentFireRate, 2).ToString() + "/s";
        fireRangeDisplay.text = "Fire Range: " + Math.Round(FindObjectOfType<WeaponController>().currentRange, 2).ToString();

        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (curState == GameState.Pause)
        {
            curState = preState;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void CheckPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (curState == GameState.Pause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void LevelUp()
    {
        curState = GameState.LevelUp;
        player.SendMessage("RemoveUpgrade");
        player.SendMessage("ApplyUpgrade");
    }

    public void FinishLevelUp()
    {
        isChosingUpgrade = false;
        Time.timeScale = 1;
        levelUpScreen.SetActive(false);
        curState = GameState.Gameplay;

    }

    public void GameOver()
    {
        curState = GameState.GameOver;
    }

    public void disableScr()
    {
        pauseScreen.SetActive(false);
        levelUpScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void UpdateStopWatch()
    {
        StopWatchTime += Time.deltaTime;

        //Divide the total number of seconds by 60 to get the number of minutes.
        //The remainder will be the number of seconds.
        minute = Mathf.FloorToInt(StopWatchTime / 60);
        sencond = Mathf.FloorToInt(StopWatchTime % 60);

        stopWatchDisplay.text = string.Format($"{minute:00}:{sencond:00}");
    }
}
