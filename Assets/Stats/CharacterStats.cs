using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;
    public bool isDeath { get; protected set; }
    void Awake()
    {
        currentHealth = maxHealth;
        isDeath = false;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetVaule();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

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
