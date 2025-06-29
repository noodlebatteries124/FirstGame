using UnityEngine;

[CreateAssetMenu(fileName = "Enemysc", menuName = "Scriptable Objects/Enemysc")]
public class Enemysc : ScriptableObject
{
    public float currentHealth;
    public float maxHealth;
    public float moveSpeed;
    public int damage;
    public int dotAmount;
    public float tickSpeed;
    public float dotDuration;
    public float damageCooldown = 0.5f;
    public float lastDamageTime = -Mathf.Infinity;
    public Vector2 moveDirection;
    public SpriteRenderer spriteRenderer;
}
