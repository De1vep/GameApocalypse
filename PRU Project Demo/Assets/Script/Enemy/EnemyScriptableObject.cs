using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Enemy stats")]
    [SerializeField] public float MaxHealth;
    [SerializeField] public float Speed;
    [SerializeField] public float Damage;
}
