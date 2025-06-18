
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
    private Vector2 lastDirection = Vector2.right;
    [SerializeField] InputActionReference move;

    //why isnt the fucking arrow flying
    // Update is called once per frame
    void Update()
    {
        Vector2 input = move.action.ReadValue<Vector2>();

        if(input != Vector2.zero)
        {
            lastDirection = input.normalized;
        }

        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            FireArrowlice();
            timer = 0f;
        }
        
        }
    private void FireArrowlice()
    {
        
       
        GameObject arrowlice = Instantiate(arrowlicePrefab, bowOffset.position, transform.rotation);
        if (lastDirection.x < 0) 
        {
            arrowlice.transform.localScale = new Vector3(-5f, 5f, 5f);
        }

        else 
        {
            arrowlice.transform.localScale = new Vector3(5f, -5f, 5f);
        }
            
        Rigidbody2D rb = arrowlice.GetComponent<Rigidbody2D>();
        rb.linearVelocity = arrowliceSpeed * lastDirection.normalized;
    }
}

   


