using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damagePerSecond = 5; // Health decrease per second
    public int damageOnHit = 20; // Health decrease when hit by an object

    public Slider healthSlider;
    public GameOverScript gameOverScript; // Reference to GameOverScript

    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        InvokeRepeating("TakeDamageOverTime", 1f, 1f);
    }

    void TakeDamageOverTime()
    {
        if (!isDead)
        {
            currentHealth -= damagePerSecond;
            if (currentHealth <= 0)
            {
                EndGame();
            }
            UpdateHealthUI();
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        if (!isDead)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                EndGame();
            }
            UpdateHealthUI();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void EndGame()
    {
        // Game over logic, e.g., show game over screen
        isDead = true;
        Debug.Log("Game Over");
        gameOverScript.ShowGameOverScreen(); // Activate game over screen
    }
}