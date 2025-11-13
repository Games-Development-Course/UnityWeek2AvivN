using UnityEngine;
using UnityEngine.InputSystem; // Imports Unity's new Input System API for keyboard input handling

public class Hider : MonoBehaviour
{
    [SerializeField] private Key toggleKey = Key.H; // Allows selecting a key from the Inspector (default: 'H')
    private Renderer rend; // Reference to the object's Renderer (controls its visibility)

    void Start()
    {
        rend = GetComponent<Renderer>(); // Gets the Renderer component attached to this GameObject
    }

    void Update()
    {
        // Checks every frame if the chosen key was pressed during this frame
        if (Keyboard.current[toggleKey].wasPressedThisFrame)
        {
            // Toggles the visibility of the object 
            rend.enabled = !rend.enabled;
        }
    }
}
