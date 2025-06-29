using UnityEngine;

public class GMoveEnemy : MonoBehaviour
{
    public Enemysc enemyScriptableObject;
    Transform Doro;
    [SerializeField] private GameObject enemy;
    public Rigidbody2D rb;
    private void Start()
    {
        enemyScriptableObject.currentHealth = enemyScriptableObject.maxHealth;
        Doro = GameObject.Find("Dorolices(garden)").transform;
    }
    void FixedUpdate()
    {
        Vector3 direction = (Doro.position - transform.position).normalized;
        enemyScriptableObject.moveDirection = direction;
        if (enemyScriptableObject.moveDirection.x < 0)
        {
            enemy.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (enemyScriptableObject.moveDirection.x > 0)
        {
            enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        rb.linearVelocity = new Vector2(enemyScriptableObject.moveDirection.x, enemyScriptableObject.moveDirection.y) * enemyScriptableObject.moveSpeed;
    }
}

