using UnityEngine;

public class StickyBar : MonoBehaviour
{
    public Transform Alice;

    private void Update()
    {
        transform.position = Alice.position;
    }
}
