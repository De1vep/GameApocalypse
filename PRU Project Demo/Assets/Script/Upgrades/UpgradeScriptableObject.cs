using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeScriptableObject", menuName = "ScriptableObject/Upgrade")]
public class UpgradeScriptableObject : ScriptableObject
{
    [SerializeField] public int Level;
    [SerializeField] public float Multiplier;
    [SerializeField] public string Name;
    [SerializeField] public string Description;
}
