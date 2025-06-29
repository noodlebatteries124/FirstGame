using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour, IDotEnemy
{
    [SerializeField] private GameObject playerlice;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float sprintSpeed;
    public Vector2 moveDirection;
    public InputActionReference move;
    public InputActionReference sprint;
    public SpriteRenderer spriteRenderer;
    public int maxHealth = 100;
    public int currentHealth;
    public NewMonoBehaviourScript player;
    public HPBar healthBar;
    public Stamina stamina;
    public int maxStamina = 100;
    public int currentStamina;
    public float staminaConsumption = 33f;
    private float timer = 0;
    private float timerEventTime = 0.1f;
    bool StartReloadingStamina = true;
    private const float _waitTime = 0.8f;
    public TrailRenderer trailRenderer;
    public int healAmount;
    public Garden garden;
    private Enemysc enemyScriptableObject;
    public float currentEffectTime = 0f;
    public float lastTickTime = 0f;
    private void Start()
    {
        sprintSpeed = moveSpeed * 1.8f;
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        stamina.setMaxStamina(maxStamina);
        stamina.setStamina(currentStamina);
    }
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        if (moveDirection.x < 0)
        {
            playerlice.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveDirection.x > 0)
        {
            playerlice.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        stamina.setStamina(currentStamina);
    }
    
    private void FixedUpdate()
    {
        if (enemyScriptableObject != null)
        {
            ((IDotEnemy)this).HandleEffect();
        }
        
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
        float speed = (move.action.IsPressed() && sprint.action.IsPressed() && currentStamina > 0) ? sprintSpeed : moveSpeed;
        rb.linearVelocity = moveDirection * speed;
        if (sprint.action.IsPressed() && currentStamina > 0)
        {
            reduceStamina(Mathf.RoundToInt(staminaConsumption * Time.fixedDeltaTime));
        }
        else if (currentStamina < maxStamina && StartReloadingStamina)
        {
            if (StartReloadingStamina)
            {
                timer += Time.fixedDeltaTime;
                if (timer >= timerEventTime)
                {

                    currentStamina += maxStamina / 30;
                    timer = 0;
                }
                if (currentStamina <= 0)
                {
                    currentStamina = 0;
                    StartCoroutine(Cooldown());
                }
            }
        }
        if (move.action.IsPressed() && sprint.action.IsPressed() && currentStamina > 0)
        {
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }
    }
    private void OnEnable()
    {
        move.action.Enable();
        sprint.action.Enable();
    }
    private void OnDisable()
    {
        move.action.Disable();
        sprint.action.Disable();
    }
    IEnumerator Cooldown()
    {
        StartReloadingStamina = false;
        yield return new WaitForSeconds(_waitTime);
        StartReloadingStamina = true;
    }
    public void TakeDamage(int damage)
    {
        healthBar.setHealth(currentHealth);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void reduceStamina(int outOfBreath)
    {
        stamina.setStamina(currentStamina);
        currentStamina -= outOfBreath;
        
        stamina.setStamina(currentStamina);
    }

    public void Apply()
    {
        healAmount = player.maxHealth / 10;
        player.currentHealth += healAmount;
        healAmount = garden.maxHealth / 10;
        garden.currentHealth += healAmount;
    }
    void IDotEnemy.ApplyEffect(Enemysc data)
    {
        this.enemyScriptableObject = data;
    }

    void IDotEnemy.RemoveEffect()
    {
        enemyScriptableObject = null;
    }
    void IDotEnemy.HandleEffect()
    {
        currentEffectTime += Time.fixedDeltaTime;
        if (currentEffectTime >= enemyScriptableObject.dotDuration)
        {
            ((IDotEnemy)this).RemoveEffect();
        }
        if (enemyScriptableObject.dotAmount != 0 && currentEffectTime > (lastTickTime + enemyScriptableObject.tickSpeed))
        {
            lastTickTime = currentEffectTime;
            currentHealth -= enemyScriptableObject.dotAmount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heals"))
        {
            Apply();
            Destroy(collision.gameObject);
        }
    }

}

    
    

