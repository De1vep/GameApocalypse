using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/Player")]
public class PlayerScriptableObject : ScriptableObject
{
	[SerializeField] public GameObject startingWeapon;
	[Header("Player stat")]
	[SerializeField] public float Speed;
	[SerializeField] public float MaxHealth;
	[SerializeField] public float Recovery;
	[SerializeField] public float PickUpRange;
	[SerializeField] public float DamageMultiplier;
	[SerializeField] public float Growth;
}
