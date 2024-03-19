public class GrowthUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        stat.currentGrowth = stat.playerData.Growth * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }
}
