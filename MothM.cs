using UnityEngine;
using System;

public class MothMini : MonoBehaviour
{

    public static event Action<MothMini> OnMothMkilled;
    [SerializeField] float health;
    [SerializeField] float maxHealth = 12f;
    [SerializeField] float moveSpeed = 3.5f;
    Rigidbody2D rb;
    Transform player;
    Vector2 moveDirection;
    public SpriteRenderer spriteRenderer;
    public int damage;
    public NewMonoBehaviourScript playerHealth;
    private float damageCooldown = 0.5f;
    private float lastDamageTime = -Mathf.Infinity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is createddd
    private void Start()
    {
        health = maxHealth;
        player = GameObject.Find("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<NewMonoBehaviourScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 direction = (player.position - transform.position).normalized; //normalized limits targets to one
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            OnMothMkilled?.Invoke(this);
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                lastDamageTime = Time.time;
                playerHealth.TakeDamage(damage);
            }
        }
    }

}
