using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    public Slider slider;
    public Image fill;




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
