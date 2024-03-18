using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
	[SerializeField] EnemyScriptableObject enemyData;
	[SerializeField] DropController drop;

	[HideInInspector] public float currentMaxHealth;
	[HideInInspector] public float currentHealth;
	[HideInInspector] public float currentSpeed;
	[HideInInspector] public float currentDamage;

	private void Awake()
	{
		currentMaxHealth = enemyData.MaxHealth;
		currentSpeed = enemyData.Speed;
		currentDamage = enemyData.Damage;
	}

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = currentMaxHealth;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Destroy(gameObject);
			drop.DropItem();
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.transform.GetComponent<PlayerStat>().takeDamage(currentDamage);
		}
	}
}
