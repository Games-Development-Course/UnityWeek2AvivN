using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    [SerializeField] private float beatSpeed = 2f; // Controls how fast the "heartbeat" pulse effect happens
    [SerializeField] private float scaleAmount = 0.3f; // Controls how much the object grows/shrinks during the beat
    private Vector3 startScale; // Stores the object's original size to use as the base scale

    void Start()
    {
        startScale = transform.localScale; // Saves the initial scale of the object when the scene starts
    }

    void Update()
    {
        // Creates a smooth oscillation between 0 and 1 using a sine wave based on time
        float scaleFactor = (Mathf.Sin(Time.time * beatSpeed) + 1f) / 2f;

        // Calculates the current scale multiplier based on the oscillation and desired scale range
        float currentScale = 1 + scaleFactor * scaleAmount;

        // Applies the new scale to the object to create the "beating" effect
        transform.localScale = startScale * currentScale;
    }
}
