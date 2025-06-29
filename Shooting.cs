
using UnityEngine;
using UnityEngine.InputSystem;
public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowlicePrefab;
    [SerializeField]
    private float arrowliceSpeed;
    [SerializeField] private float fireRate;
    [SerializeField]
    private Transform bowOffset;
    private float timer;
    private Vector2 lastDirection;
    [SerializeField] InputActionReference move;
    private Animator animator;
    public Rigidbody2D rb;
    //why isnt the fucking arrow flying
    // Update is called once per frame

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        
        Vector2 input = move.action.ReadValue<Vector2>();
        if(input != Vector2.zero)
        {
            lastDirection = input.normalized;
        }

        timer += Time.fixedDeltaTime;
        if (timer >= fireRate)
        {
            FireArrowlice();
            timer = 0f;
        }
        

    }
    private void FireArrowlice()
    {  
        GameObject arrowlice = Instantiate(arrowlicePrefab, bowOffset.position, Quaternion.identity);
        arrowlice.transform.right = lastDirection;
        Rigidbody2D rb = arrowlice.GetComponent<Rigidbody2D>();
        rb.linearVelocity = arrowliceSpeed * lastDirection.normalized;
        animator.SetTrigger("IsShooting");
    }
   


}




