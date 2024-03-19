public class GunFireRateUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        FindObjectOfType<WeaponController>().currentFireRate = FindObjectOfType<WeaponController>().gunData.fireRate / (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }
}