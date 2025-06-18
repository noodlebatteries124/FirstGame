using UnityEngine;

public class StickyBar : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = player.position;
    }
}
