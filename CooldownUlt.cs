using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class CooldownUlt : MonoBehaviour
{
    public Image ultimate;
    [SerializeField] InputActionReference ult;
    [SerializeField] private UltShooting UltShooting;
    bool isCooldown = true;
    void Start()
    {
        ultimate.fillAmount = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerUltimate();
    }

    void PlayerUltimate()
    {
        if (ult.action.IsPressed() && isCooldown == false)
        {
            isCooldown = true;
            ultimate.fillAmount = 1;
        }
        if(isCooldown == true)
        {
            ultimate.fillAmount -= 1/ UltShooting.ultFireRate * Time.fixedDeltaTime; 
            if (ultimate.fillAmount <= 0)
            {
                ultimate.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
