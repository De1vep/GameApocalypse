using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        public List<Upgrade> Upgrades = new List<Upgrade>();

        [System.Serializable]
        public class UpgradeUI
        {
            public Text upgradeName;
            public Text upgradeDescription;
            public Button btn;
        }

        [SerializeField] public List<UpgradeUI> uis = new List<UpgradeUI>();


        public void LevelUpgrade(int index)
        {
            Debug.Log("Upgrade index: " + index);
            if (index == 0)
            {
                FindObjectOfType<DamageMultiUpgrade>().LevelUp();
            }
            if (index == 1)
            {
                FindObjectOfType<HealthUpgrade>().LevelUp();
            }
            if (index == 2)
            {
                FindObjectOfType<GrowthUpgrade>().LevelUp();
            }
            if (index == 3)
            {
                FindObjectOfType<MoveSpeedUpgrade>().LevelUp();
            }
            if (index == 4)
            {
                FindObjectOfType<PickUpRangeUpgrade>().LevelUp();
            }
            if (index == 5)
            {
                FindObjectOfType<RecoveryUpgrade>().LevelUp();
            }
            if (index == 6)
            {
                FindObjectOfType<GunRangeUpgrade>().LevelUp();
            }
            if (index == 7)
            {
                FindObjectOfType<GunFireRateUpgrade>().LevelUp();
            }
            if (index == 8)
            {
                FindObjectOfType<MoveSpeedUpgrade>().LevelUp();
            }
            GameManager.instance.FinishLevelUp();
        }

        public void ApplyUpgrade()
        {
            //Pick 3 random upgrade from list
            List<Upgrade> upgradeOption = new List<Upgrade>();
            while (upgradeOption.Count < 3)
            {
                Upgrade upgrade = Upgrades.ElementAt(UnityEngine.Random.Range(0, Upgrades.Count()));
                if (upgradeOption.Where(u => u.upgradeData.Name.Equals(upgrade.upgradeData.Name)).Count() == 0)
                {
                    upgradeOption.Add(upgrade);
                }
            }
            int index = 0;
            //Set to UI
            Debug.Log(upgradeOption.Count());
            foreach (UpgradeUI ui in uis)
            {
                int i = Upgrades.IndexOf(upgradeOption[index]);
                ui.btn.onClick.AddListener(() => LevelUpgrade(i));
                ui.upgradeName.text = upgradeOption[index].upgradeData.Name;
                ui.upgradeDescription.text = upgradeOption[index].upgradeData.Description;
                index++;
            }
        }

        public void RemoveUpgrade()
        {
            foreach (UpgradeUI ui in uis)
            {
                ui.btn.onClick.RemoveAllListeners();
            }
        }
    }
}
