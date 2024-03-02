using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int healthAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseHealth(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}