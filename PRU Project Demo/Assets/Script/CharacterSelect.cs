using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
	[SerializeField] public static CharacterSelect instance;
	[SerializeField] public GunScriptableObject gunData;
	[SerializeField] public PlayerScriptableObject playerData;
	[SerializeField] public GameObject startingWeapon;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			//playerData.startingWeapon = startingWeapon;

			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public static PlayerScriptableObject GetPlayerData()
	{
		return instance.playerData;
	}

	public static GunScriptableObject GetGunData()
	{
		return instance.gunData;
	}

	public void SelectWeaponData(GunScriptableObject gun)
	{
		gunData = gun;
	}

	public void SelectWeapon(GameObject gun)
	{
		playerData.startingWeapon = gun;
	}

	public void SelectPlayer(PlayerScriptableObject player)
	{
		playerData = player;
	}
}
