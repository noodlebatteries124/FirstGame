using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject playerlice;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float sprintSpeed;
    public Vector2 moveDirection;
    public InputActionReference move;
    public InputActionReference sprint;
    private SpriteRenderer spriteRenderer;
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

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
        currentStamina = maxStamina;
        stamina.setMaxStamina(maxStamina);
        stamina.setStamina(currentStamina);

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        sprintSpeed = moveSpeed * 1.8f;
        moveDirection = move.action.ReadValue<Vector2>();
        if (moveDirection.x < 0)
        {
            playerlice.transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else if (moveDirection.x > 0)
        {
            playerlice.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        stamina.setStamina(currentStamina);


    }
    private void FixedUpdate()
    {
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
        
    }

    IEnumerator Cooldown()
    {
        StartReloadingStamina = false;
        // wait for set amount of time
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


    private void OnMove()
    {
        Debug.Log("move");
    }
    private void OnSprint()
    {
        Debug.Log("sprint");
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
    
}
