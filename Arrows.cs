
using UnityEngine;
using UnityEngine.InputSystem;

public class Arrows : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    [SerializeField] GameObject ArrowlicePrefab;
    public float dealDamage = 12;
    [SerializeField] private float lifetime = 1f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void Update()   
    {
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.TryGetComponent<MothMini>(out MothMini MothMiniComponent))
      {
       MothMiniComponent.TakeDamage(dealDamage);
       Destroy(gameObject);
      }      
    }   

    
}
//float angle = MathF.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
//rb.rotation = angle;