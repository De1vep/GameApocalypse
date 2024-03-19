public class GunRangeUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        FindObjectOfType<WeaponController>().currentRange = FindObjectOfType<WeaponController>().gunData.range * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }
}
