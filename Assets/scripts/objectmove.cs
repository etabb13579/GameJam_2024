using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmove : MonoBehaviour
{
    public float speed = 5f; // Speed at which the object moves
    public Vector3 direction = Vector3.forward; // Direction in which the object moves

    void Update()
    {
        // Move the object based on the direction and speed
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
