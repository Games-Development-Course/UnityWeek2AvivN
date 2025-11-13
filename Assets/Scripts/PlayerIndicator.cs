using UnityEngine;

public class MinimapIndicator : MonoBehaviour
{
    public Transform player;         // the real player in the world
    public RectTransform minimapRect; // the UI minimap RectTransform
    public Vector2 minBounds;        // world min position (ground min)
    public Vector2 maxBounds;        // world max position (ground max)

    private RectTransform dot;

    void Start()
    {
        dot = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Normalize player position (0..1)
        float xNorm = Mathf.InverseLerp(minBounds.x, maxBounds.x, player.position.x);
        float yNorm = Mathf.InverseLerp(minBounds.y, maxBounds.y, player.position.y);

        // Convert to minimap UI coordinates
        float xPos = (xNorm - 0.5f) * minimapRect.rect.width;
        float yPos = (yNorm - 0.5f) * minimapRect.rect.height;

        dot.anchoredPosition = new Vector2(xPos, yPos);
    }
}
