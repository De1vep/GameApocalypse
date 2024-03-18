using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMultiUpgrade : Upgrade
{
	public override void ApplyModifier()
	{
		stat.currentDamageMultiplier = stat.playerData.DamageMultiplier * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
	}
}
