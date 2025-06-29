using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    [SerializeField] private GameObject staminaBar;

    private void Awake()
    {
        staminaBar.transform.position = new Vector3(0f, -1.90f, 1f);
    }

    public void setMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
        
    }
    public void setStamina(int currentStamina)
    {
        slider.value = currentStamina;
    } 

}
