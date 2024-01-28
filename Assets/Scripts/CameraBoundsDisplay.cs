using UnityEngine;

[ExecuteInEditMode]
public class CameraBoundsDisplay : MonoBehaviour
{
    private Camera mainCamera;

    private void OnEnable()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void OnDrawGizmos()
    {
        if (mainCamera == null)
            return;

        DrawCameraBounds();
    }

    private void DrawCameraBounds()
    {
        float cameraSize = mainCamera.orthographicSize;
        float cameraAspect = mainCamera.aspect;
        float cameraWidth = cameraSize * cameraAspect;

        Vector3 cameraPosition = mainCamera.transform.position;

        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector3(cameraPosition.x - cameraWidth, cameraPosition.y - cameraSize, 0f),
                        new Vector3(cameraPosition.x - cameraWidth, cameraPosition.y + cameraSize, 0f));

        Gizmos.DrawLine(new Vector3(cameraPosition.x + cameraWidth, cameraPosition.y - cameraSize, 0f),
                        new Vector3(cameraPosition.x + cameraWidth, cameraPosition.y + cameraSize, 0f));

        Gizmos.DrawLine(new Vector3(cameraPosition.x - cameraWidth, cameraPosition.y - cameraSize, 0f),
                        new Vector3(cameraPosition.x + cameraWidth, cameraPosition.y - cameraSize, 0f));

        Gizmos.DrawLine(new Vector3(cameraPosition.x - cameraWidth, cameraPosition.y + cameraSize, 0f),
                        new Vector3(cameraPosition.x + cameraWidth, cameraPosition.y + cameraSize, 0f));
    }
}