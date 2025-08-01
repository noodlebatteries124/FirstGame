using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField] private GameObject hpBar;


    private void Awake()
    {
        hpBar.transform.position = new Vector3(0f, -1.25f, 1f);
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void setHealth(int currentHealth)
    {
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
   
}
