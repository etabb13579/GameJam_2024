using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{

    public float boostAmount = 2f; // Amount to increase player's speed by
    public float boostDuration = 3f; // Duration of the boost
    public GameObject player; // Reference to the player GameObject

    private bool isBoosted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBoosted)
        {
            isBoosted = true;
            StartCoroutine(BoostPlayer());
            Destroy(gameObject); // Destroy the item after it's been collected
        }
    }

    IEnumerator BoostPlayer()
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed += boostAmount;

        yield return new WaitForSeconds(boostDuration);

        playerMovement.moveSpeed -= boostAmount;
        isBoosted = false;
    }
}
