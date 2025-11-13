using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // השחקן
    public float smoothSpeed = 5f; // מהירות תזוזת המצלמה
    public Vector3 offset;         // מרחק קבוע מהשחקן

    // גבולות המפה
    public Vector2 minBounds = new Vector2(-14f, -5f);
    public Vector2 maxBounds = new Vector2(14f, 5f);

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        // חישוב מחצית גובה ורוחב המצלמה (חשוב כדי שלא תראה מעבר לגבולות)
        Camera cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // מיקום היעד (שחקן + היסט)
        Vector3 desiredPosition = target.position + offset;

        // תנועה חלקה למיקום החדש
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // --- הגבלת תנועת המצלמה לגבולות המפה ---
        float clampX = Mathf.Clamp(smoothedPosition.x,
            minBounds.x + halfWidth,
            maxBounds.x - halfWidth);

        float clampY = Mathf.Clamp(smoothedPosition.y,
            minBounds.y + halfHeight,
            maxBounds.y - halfHeight);

        transform.position = new Vector3(clampX, clampY, smoothedPosition.z);
    }
}
