
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    [SerializeField] GameObject ArrowlicePrefab;
    public float dealDamage = 12;
    [SerializeField] private float lifetime = 2f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.TryGetComponent<HPEnemy>(out HPEnemy enemyHp))
      {
       enemyHp.TakeDamage(dealDamage);
       Destroy(gameObject);
      }      
    }   

    
}
//float angle = MathF.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
//rb.rotation = angle;