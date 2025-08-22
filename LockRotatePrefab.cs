using UnityEngine;

public class LockRotatePrefab : MonoBehaviour
{
    // Rotation constraints
    public bool constrainXRotation = false;
    public bool constrainYRotation = false;
    public bool constrainZRotation = false;

    void Update()
    {
        // Apply rotation constraints
        ApplyRotationConstraints();
    }

    void ApplyRotationConstraints()
    {
        // Get the current rotation of the prefab
        Quaternion currentRotation = transform.rotation;

        // Calculate the new rotation, applying constraints
        Quaternion newRotation = Quaternion.Euler(
            constrainXRotation ? 0 : currentRotation.eulerAngles.x,
            constrainYRotation ? 0 : currentRotation.eulerAngles.y,
            constrainZRotation ? 0 : currentRotation.eulerAngles.z
        );

        // Apply the new rotation to the prefab
        transform.rotation = newRotation;
    }
}
