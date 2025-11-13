using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);
    // Determines how fast and around which axes the object will rotate (degrees per second)

    void Update()
    {
        // Rotates the object continuously every frame based on rotationSpeed
        // Time.deltaTime ensures smooth rotation that is frame-rate independent
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
