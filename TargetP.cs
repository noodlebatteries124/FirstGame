using UnityEngine;

public class TargetP : MonoBehaviour
{
    public Enemysc enemyScriptableObject;
    public NewMonoBehaviourScript playerHealth;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - enemyScriptableObject.lastDamageTime >= enemyScriptableObject.damageCooldown)
            {
                enemyScriptableObject.lastDamageTime = Time.time;
                playerHealth.TakeDamage(enemyScriptableObject.damage);
            }
        }
    }
}
