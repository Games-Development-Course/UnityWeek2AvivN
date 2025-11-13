using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.right;
    // The direction in which the object will move (default: right along the X-axis)

    [SerializeField] private float speed = 2f;
    // The movement speed of the object in units per second

    void Update()
    {
        // Moves the object continuously every frame in the chosen direction
        // Multiplied by Time.deltaTime to ensure consistent speed across different frame rates
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
