public class PickUpRangeUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        stat.currentPickUpRange = stat.playerData.PickUpRange * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }
}
