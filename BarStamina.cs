using UnityEngine;

public class BarStamina : MonoBehaviour
{
    public Transform Alice;
    private void Update()
    {
        transform.position = Alice.position;
    }
}
