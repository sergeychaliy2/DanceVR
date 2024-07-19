using UnityEngine;
using UnityEngine.EventSystems;

public class PanelMover : MonoBehaviour
{
    [Header("Mover")][Space]
    [SerializeField] private float maxDistance = 2.0f;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Camera mainCamera;
    private Vector3 initialPosition;
    private Vector3 currentVelocity = Vector3.zero;
    private bool isPointerOver = false;

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
