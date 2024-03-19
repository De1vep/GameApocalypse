public class RecoveryUpgrade : Upgrade
{
    public override void ApplyModifier()
    {
        if (stat.currentRecovery == 0 && upgradeData.Level == 1)
        {
            stat.currentRecovery = (upgradeData.Multiplier * currentUpgradeLevel) / 100;
        }
        else if (stat.playerData.Recovery == 0 && upgradeData.Level > 1)
        {
            stat.currentRecovery = 0.2f * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
        }
        else
        {
            stat.currentRecovery = stat.playerData.Recovery * (1 + (upgradeData.Multiplier * currentUpgradeLevel) / 100);
        }

    }
}
