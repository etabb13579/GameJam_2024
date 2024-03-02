using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdperson : MonoBehaviour
{
    public Transform target; // The target to follow
    public Vector3 offset = new Vector3(0f, 1.5f, -5f); // Offset from the target

    public float sensitivityX = 4f; // Mouse sensitivity for X axis
    public float sensitivityY = 1f; // Mouse sensitivity for Y axis
    public float minYAngle = -20f; // Minimum Y angle
    public float maxYAngle = 80f; // Maximum Y angle

    private float currentX = 0f; // Current X rotation
    private float currentY = 0f; // Current Y rotation

    void LateUpdate()
    {
        if (target == null)
            return;

        // Get mouse input for rotation
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        // Clamp Y angle between min and max values
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        // Set camera rotation based on mouse input
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);

        // Calculate desired position based on target's position and offset
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smoothly interpolate between current position and desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);

        // Look at the target
        transform.LookAt(target);
    }
}
