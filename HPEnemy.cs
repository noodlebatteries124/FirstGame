using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    public Enemysc enemyScriptableObject;
    public Lootbag lootbag;
    public void TakeDamage(float damage)
    {
        enemyScriptableObject.currentHealth -= damage;
        if (enemyScriptableObject.currentHealth <= 0)
        {
            lootbag.InstantiateLoot(transform.position);
            Destroy(gameObject);
        }
    }

}
