using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropCollect : MonoBehaviour
{
	PlayerStat playerData;

	private void Start()
	{
		playerData = FindObjectOfType<PlayerStat>();
	}

	private void Update()
	{
		gameObject.GetComponent<CircleCollider2D>().radius = playerData.currentPickUpRange;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Exp"))
		{						
			collision.gameObject.GetComponent<ExpGem>().Collect();
		}
	}
}
