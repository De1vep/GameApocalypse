using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
	public override void ApplyModifier()
	{
		float oldMaxHealth = stat.currentMaxHealth;
		stat.currentMaxHealth = stat.playerData.MaxHealth * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
		stat.currentHealth += stat.currentMaxHealth - oldMaxHealth;
	}
}
