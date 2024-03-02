using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattractor : MonoBehaviour
{
    public float attractionRadius = 10f; // Radius within which enemies are attracted
    public float attractionForce = 5f; // Force at which enemies are attracted
    public LayerMask enemyLayer; // Layer mask for enemies

    private List<Rigidbody> attractedEnemies = new List<Rigidbody>(); // List of attracted enemies

    void FixedUpdate()
    {
        // Find all enemies within the attraction radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius, enemyLayer);

        // Clear list of attracted enemies
        attractedEnemies.Clear();

        // Add attracted enemies to the list
        foreach (Collider col in colliders)
        {
            Rigidbody enemyRB = col.GetComponent<Rigidbody>();
            if (enemyRB != null && !attractedEnemies.Contains(enemyRB))
            {
                attractedEnemies.Add(enemyRB);
            }
        }

        // Apply attraction force to attracted enemies
        foreach (Rigidbody enemyRB in attractedEnemies)
        {
            Vector3 attractionDirection = (transform.position - enemyRB.position).normalized;
            enemyRB.AddForce(attractionDirection * attractionForce, ForceMode.Force);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw attraction radius in scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
    }

}
