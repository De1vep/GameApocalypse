public class DamageMultiUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        stat.currentDamageMultiplier = stat.playerData.DamageMultiplier * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }
}
