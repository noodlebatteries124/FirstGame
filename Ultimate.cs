using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    [SerializeField] GameObject UltimatePrefab;
    public float dealDamage = 100;
    [SerializeField] private float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HPEnemy>(out HPEnemy Enemy))
        {
            Enemy.TakeDamage(dealDamage);
        }
    }
}
