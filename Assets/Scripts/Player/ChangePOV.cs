using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    public float rotationSpeed = 180f;

    private bool isRotating = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isRotating)
        {
            RotatePlayer180Degrees();
        }
    }

    void RotatePlayer180Degrees()
    {
        // Calculate the target rotation as a quaternion
        Quaternion targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + 180f, 0f);

        StartCoroutine(RotatePlayerSmoothly(targetRotation, rotationSpeed));
    }

    IEnumerator RotatePlayerSmoothly(Quaternion targetRotation, float speed)
    {
        isRotating = true;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            // Interpolate between the current rotation and the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            yield return null;
        }

        isRotating = false;
    }
}
