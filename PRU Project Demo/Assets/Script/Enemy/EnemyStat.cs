using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject enemyData;
    [SerializeField] DropController drop;
    [SerializeField] Animator animator;
    [SerializeField] Image healthBar;

    [HideInInspector] public float currentMaxHealth;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float currentDamage;

    [HideInInspector] public bool isDead = false;

    private void Awake()
    {
        currentMaxHealth = enemyData.MaxHealth;
        currentSpeed = enemyData.Speed;
        currentDamage = enemyData.Damage;
        currentHealth = currentMaxHealth;
        healthBar.fillAmount = currentHealth / currentMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / currentMaxHealth;
        if (currentHealth <= 0)
        {
            isDead = true;
            animator.SetTrigger("Dead");    
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        drop.DropItem();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerStat>().takeDamage(currentDamage);
        }
    }
}
