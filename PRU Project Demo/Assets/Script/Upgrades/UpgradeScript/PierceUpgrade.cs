public class PierceUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        FindObjectOfType<WeaponController>().currentPierce = FindObjectOfType<WeaponController>().gunData.pierce * (1 + (int)(upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }
}
