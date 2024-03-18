using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "ScriptableObject/Gun")]
public class GunScriptableObject : ScriptableObject
{
	[Header("Weapon stats")]
	[SerializeField] public GameObject prefab;
	[SerializeField] public float damage;
	[SerializeField] public float speed;
	[SerializeField] public float fireRate;
	[SerializeField] public int pierce;
	[SerializeField] public float range;
	[SerializeField] public float spread;
}
