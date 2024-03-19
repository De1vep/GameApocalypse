using Assets.Script.Upgrades;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] public PlayerScriptableObject playerData;

    [Header("Defaul")]
    [SerializeField] public GameObject defaultGun;

    //Current stat
    [Header("Player stat")]
    [SerializeField] public float currentSpeed;
    [SerializeField] public float currentMaxHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public float currentRecovery;
    [SerializeField] public float currentDamageMultiplier;
    [SerializeField] public float currentPickUpRange;
    [SerializeField] public float currentGrowth;
    private float recoveryTimer = 1;

    //private bool isFacingRight = true;
    //Invincible frame I-Frame
    private bool isInvincible = false;
    private float iFrameDuration = 1;

    //Level and exp
    [Header("EXP & Level")]
    [SerializeField] public float EXP = 0;
    [SerializeField] public int Level = 1;
    [SerializeField] public int ExpCap;

    //Class for defining a level range and the corresponding expCap for that range
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int expCapIncrease;
    }
    [SerializeField] public List<LevelRange> levelRanges;

    [Header("UI")]
    [SerializeField] public Image expBar;
    [SerializeField] public Text levelDisplay;
    [SerializeField] public Image healthBar;
    [SerializeField] public Text healthDisplay;

    public UpgradeManager manager;

    void Start()
    {
        ExpCap = levelRanges[0].expCapIncrease;
    }

    void Awake()
    {
        playerData = CharacterSelect.GetPlayerData();
        if (playerData.startingWeapon == null)
        {
            playerData.startingWeapon = defaultGun;
        }

        manager = GetComponent<UpgradeManager>();

        currentSpeed = playerData.Speed;
        currentMaxHealth = playerData.MaxHealth;
        currentHealth = currentMaxHealth;
        currentRecovery = playerData.Recovery;
        currentDamageMultiplier = playerData.DamageMultiplier;
        currentPickUpRange = playerData.PickUpRange;
        currentGrowth = playerData.Growth;

        SpawnGun(playerData.startingWeapon);
        SpawnUpgrade();

        UpdateExpBar();
        UpdateLevelDisplay();
        UpdateHealthBar();
    }

    private void Update()
    {
        if (GetComponent<PlayerMovement>().isDead)
        {
            return;
        }

        if (isInvincible)
        {
            iFrameDuration -= Time.deltaTime;
            if (iFrameDuration <= 0)
            {
                isInvincible = false;
            }
        }
        Recovery();
    }

    public void IncreaseExp(float amount)
    {
        EXP += amount * currentGrowth;
        Debug.Log("Current growth: " + currentGrowth + ", exp drop: " + amount + ", pickup amount: " + amount * currentGrowth);
        LevelUpCheck();
        UpdateExpBar();
    }

    void LevelUpCheck()
    {
        if (EXP > ExpCap)
        {
            Level++;
            EXP -= ExpCap;
            foreach (LevelRange range in levelRanges)
            {
                if (Level >= range.startLevel && range.endLevel >= range.startLevel)
                {
                    ExpCap += range.expCapIncrease;
                    break;
                }
            }
            UpdateLevelDisplay();
            GameManager.instance.LevelUp();
        }
    }

    public void takeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            UpdateHealthBar();
            if (currentHealth <= 0)
            {
                GameManager.instance.GameOver();
                GetComponent<PlayerMovement>().isDead = true;
            }
            isInvincible = true;
            iFrameDuration = 1;
        }
    }

    public void Recovery()
    {
        recoveryTimer -= Time.deltaTime;
        if (currentHealth < currentMaxHealth && recoveryTimer <= 0)
        {
            currentHealth += currentRecovery;
            recoveryTimer = 1;
            if (currentHealth > currentMaxHealth)
            {
                currentHealth = currentMaxHealth;
            }
            UpdateHealthBar();
        }
    }

    public void SpawnGun(GameObject gun)
    {
        GameObject g = Instantiate(gun,
            transform.position,
            Quaternion.identity, transform);
    }

    public void SpawnUpgrade()
    {
        foreach (Upgrade upgrade in manager.Upgrades)
        {
            Instantiate(upgrade, transform.position, Quaternion.identity, transform);
        }
    }



    public void UpdateExpBar()
    {
        expBar.fillAmount = EXP / ExpCap;
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / currentMaxHealth;
        healthDisplay.text = (int)Mathf.Round(currentHealth) + "/" + (int)Mathf.Round(currentMaxHealth);
    }

    public void UpdateLevelDisplay()
    {
        levelDisplay.text = "Level " + Level.ToString();
    }

}
