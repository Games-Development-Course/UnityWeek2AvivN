using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector = new Vector3(3f, 0f, 0f);
    // Defines the distance and direction the object will move from its starting point

    [SerializeField] private float period = 2f;
    // Time (in seconds) for one complete back-and-forth oscillation

    private Vector3 startingPos;
    // Stores the object's initial position to calculate relative motion

    private float movementFactor;
    // (Optional variable) represents normalized position between start and end — not directly used here but useful for visualization

    void Start()
    {
        startingPos = transform.position;
        // Records the initial position at the start of the game
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        // Prevents division by zero or extremely small period values

        float cycles = Time.time / period;
        // Calculates how many oscillation cycles have passed since the game started

        const float tau = Mathf.PI * 2f;
        // Tau is a constant representing one full circle in radians 

        float rawSinWave = Mathf.Sin(cycles * tau);
        // Generates a smooth sine wave oscillation between -1 and 1

        Vector3 offset = movementVector * rawSinWave;
        // Scales the sine wave to the desired movement range and direction

        transform.position = startingPos + offset;
        // Moves the object back and forth around its original position
    }
}
