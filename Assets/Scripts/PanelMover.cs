using UnityEngine;
using UnityEngine.EventSystems;

public class PanelMover : MonoBehaviour
{
    public float maxDistance = 2.0f;
    public float smoothTime = 0.3f;

    private Vector3 initialPosition;
    private Vector3 currentVelocity = Vector3.zero;
    private bool isPointerOver = false;

    private Camera mainCamera;

    void Start()
    {
        initialPosition = transform.position;
        mainCamera = Camera.main; 
    }

    void Update()
    {
        Vector3 targetPosition = isPointerOver ? GetTargetPosition() : initialPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
       // Debug.Log($"Current position: {transform.position}, Target position: {targetPosition}, isPointerOver: {isPointerOver}");
    }

    private Vector3 GetTargetPosition()
    {
        Vector3 directionToCamera = (mainCamera.transform.position - initialPosition).normalized;
        Vector3 targetPosition = initialPosition + directionToCamera * maxDistance;
        return targetPosition;
    }

    public void OnPointerEnter()
    {
        isPointerOver = true;
    }

    public void OnPointerExit()
    {
        isPointerOver = false;
    }
}
