using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class CameraMover : MonoBehaviour
{
    public Camera cameraToMove;
    public Vector3 targetPosition;
    public float duration = 1.0f;

    private Vector3 startPosition;
    private float timeElapsed;
    public UnityEvent onEndCameraMove;

    public void MoveCamera()
    {
        startPosition = cameraToMove.transform.position;
        timeElapsed = 0f;
        StartCoroutine(MoveCameraCoroutine());
    }

    private IEnumerator MoveCameraCoroutine()
    {
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            t = t * t;  // Easing quadratica
            cameraToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        cameraToMove.transform.position = targetPosition;
        onEndCameraMove?.Invoke();
    }
}