using UnityEngine;
using UnityEngine.U2D.Animation;

public class Heals : MonoBehaviour
{
    public int healAmount;
    public NewMonoBehaviourScript Alice;
    public Garden garden;
    public SpriteRenderer spriteRenderer;

    public void Apply()
    {
        healAmount = Alice.maxHealth / 10;
        healAmount = garden.maxHealth / 10;
        Alice.currentHealth += healAmount;
        garden.currentHealth += healAmount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Apply();
            Destroy(gameObject);
        }
    }
}
