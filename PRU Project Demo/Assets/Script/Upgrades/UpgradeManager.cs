using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Upgrades
{
	public class UpgradeManager : MonoBehaviour
	{
		public List<Upgrade> Upgrades = new List<Upgrade>();

		public void LevelUpUpgrade(Upgrade upgrade)
		{
			//Upgrades.Where(u => u.upgradeData.Name.Equals(upgrade.upgradeData.Name)).FirstOrDefault().LevelUp();
			//int index = Upgrades.IndexOf(up);
			//up.currentUpgradeLevel++;
			//up.ApplyModifier();
			//upgrade.LevelUp();

		}
	}
}
