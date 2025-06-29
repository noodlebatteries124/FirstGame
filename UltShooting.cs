using UnityEngine;
using UnityEngine.InputSystem;
public class UltShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject ultimatePrefab;
    public float ultSpeed;
    public float ultFireRate;
    [SerializeField] private Transform ultOffset;
    public float timer;
    private Vector2 lastDirection;
    [SerializeField] InputActionReference ult;
    [SerializeField] InputActionReference move;
    public Rigidbody2D rb;
    void FixedUpdate()
    {
        Vector2 input = move.action.ReadValue<Vector2>();
        if (input != Vector2.zero)
        {
            lastDirection = input.normalized;
        }
        timer += Time.fixedDeltaTime;
        if (timer >= ultFireRate && ult.action.IsPressed())
        {
            Ultimate();
            timer = 0f;
        }
    }
    private void Ultimate()
    {
        GameObject ultimate = Instantiate(ultimatePrefab, ultOffset.position, Quaternion.identity);
        ultimate.transform.right = lastDirection;
        Rigidbody2D rb = ultimate.GetComponent<Rigidbody2D>();
        rb.linearVelocity = ultSpeed * lastDirection.normalized;
    }
     

    void OnEnable()
    {
        ult.action.Enable();
    }

    void OnDisable()
    {
        ult.action.Disable();
    }
}
