using Assets.Script.Upgrades;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
	[SerializeField] public PlayerScriptableObject playerData;


	//Current stat
	[Header("Player stat")]
	[HideInInspector] public float currentSpeed;
	[SerializeField] public float currentMaxHealth;
	[SerializeField] public float currentHealth;
	[HideInInspector] public float currentRecovery;
	[SerializeField] public float currentDamageMultiplier;
	[HideInInspector] public float currentPickUpRange;
	[HideInInspector] public float currentGrowth;
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

	public UpgradeManager manager;

	void Start()
	{
		ExpCap = levelRanges[0].expCapIncrease;
	}

	void Awake()
    {
		playerData = CharacterSelect.GetPlayerData();
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

		//LevelUpgrade(test);
	}

	private void Update()
	{
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
		EXP += amount;
		LevelUpCheck();
	}

	void LevelUpCheck()
	{
		if(EXP > ExpCap)
		{
			Level++;
			Debug.Log("Level up, current level: " + Level);
			EXP -= ExpCap;
			foreach(LevelRange range in levelRanges)
			{
				if(Level >= range.startLevel &&  range.endLevel >= range.startLevel)
				{
					ExpCap += range.expCapIncrease;
					break;
				}
			}
		}
	}

	public void takeDamage(float damage)
	{
		if (!isInvincible)
		{			
			currentHealth -= damage;
			Debug.Log("currentHealth: " + currentHealth);
			if (currentHealth <= 0)
			{
				Destroy(gameObject);
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
			Debug.Log("Recover, current health: " + currentHealth);
			recoveryTimer = 1;
			if (currentHealth > currentMaxHealth)
			{
				currentHealth = currentMaxHealth;
			}
		}		
	}

	public void SpawnGun(GameObject gun)
	{
		GameObject g = Instantiate(gun, 
			new Vector3(transform.position.x, transform.position.y + 0.63f, transform.position.z),
			Quaternion.identity, transform);
	}

	public void SpawnUpgrade()
	{
		foreach(Upgrade upgrade in manager.Upgrades)
		{
			Instantiate(upgrade,
			new Vector3(transform.position.x, transform.position.y + 0.63f, transform.position.z),
			Quaternion.identity, transform);
		}
	}

	public void LevelUpgrade(int index)
	{
		if(index == 1)
		{
			FindObjectOfType<DamageMultiUpgrade>().LevelUp();
		}
		if(index == 2)
		{
			FindObjectOfType<HealthUpgrade>().LevelUp();
		}
	}

}
