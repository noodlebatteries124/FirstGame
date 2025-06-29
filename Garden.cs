using UnityEngine;

public class Garden : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Rigidbody2D rb;
    public HPGarden healthBar;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        healthBar.setHealth(currentHealth);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
