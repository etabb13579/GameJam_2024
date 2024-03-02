using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;

    void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("Player Health reference is not set in HealthBarScript.");
            return;
        }
        slider.maxValue = playerHealth.maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        if (playerHealth == null)
        {
            Debug.LogError("Player Health reference is not set in HealthBarScript.");
            return;
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (slider == null)
        {
            Debug.LogError("Slider reference is not set in HealthBarScript.");
            return;
        }
        slider.value = playerHealth.currentHealth;
    }
}
