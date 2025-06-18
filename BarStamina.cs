using UnityEngine;

public class BarStamina : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = player.position + new Vector3(0f, -0.3f, 1f);
    }
}
