using UnityEngine;

public class TargetG : MonoBehaviour
{
    public Enemysc enemyScriptableObject;
    public Garden gardenHealth;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Garden"))
        {
            if (Time.time - enemyScriptableObject.lastDamageTime >= enemyScriptableObject.damageCooldown)
            {
                enemyScriptableObject.lastDamageTime = Time.time;
                gardenHealth.TakeDamage(enemyScriptableObject.damage);
            }
        }
    }
}
