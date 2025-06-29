using UnityEngine;

public class Dot : MonoBehaviour
{
    public Enemysc enemyScriptableObject;
    public NewMonoBehaviourScript playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - enemyScriptableObject.lastDamageTime >= enemyScriptableObject.damageCooldown)
            {
                var effectable = collision.gameObject.GetComponent<IDotEnemy>();
                if(effectable != null)
                {
                    effectable.ApplyEffect(enemyScriptableObject);
                } 
                enemyScriptableObject.lastDamageTime = Time.time;
                playerHealth.TakeDamage(enemyScriptableObject.damage);
            }
        }
    }
}
