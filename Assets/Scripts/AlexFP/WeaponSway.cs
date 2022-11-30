using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializedField] private float smooth;
    [SerializedField] private float multiplier;

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * multiplier * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * multiplier * Time.deltaTime;

        // Calculate Target Rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseX, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(-mouseY, Vector3.right);

        Quaternion targetRotation = rotationX * rotationY;

        // rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
