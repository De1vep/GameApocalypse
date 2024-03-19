public class MoveSpeedUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        stat.currentSpeed = stat.playerData.Speed * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
    }

}
