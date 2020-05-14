using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth { get; protected set; }
    public Stat damage;
    public Stat armor;
    public bool isDeath { get; protected set; }
    public bool isAttacking;

    public HealthBar healthBar;

    public int level;
    public string name;

    void Start()
    {
    }
    void Awake()
    {
        name = "Przemek";
        level = 1;
        currentHealth = maxHealth;
        isDeath = false;
        isAttacking = false;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(transform.name + "died");
    }
}
