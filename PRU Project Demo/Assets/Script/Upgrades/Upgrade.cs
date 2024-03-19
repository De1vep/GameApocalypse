using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public PlayerStat stat;
    [SerializeField] public UpgradeScriptableObject upgradeData;

    public int currentUpgradeLevel;

    private void Awake()
    {
        currentUpgradeLevel = upgradeData.Level;
    }

    // Start is called before the first frame update
    void Start()
    {
        stat = FindObjectOfType<PlayerStat>();

        ApplyModifier();
    }

    public virtual void ApplyModifier()
    {

    }

    public void LevelUp()
    {
        currentUpgradeLevel++;
        ApplyModifier();
    }
}
