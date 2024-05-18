using UnityEngine;
using UnityEngine.EventSystems;

public class PanelMover : MonoBehaviour
{
    public float maxDistance = 2.0f; // Максимальное расстояние, на которое панель может приближаться к камере
    public float smoothTime = 0.3f; // Время сглаживания

    private Vector3 initialPosition; // Начальная позиция панели в мировых координатах
    private Vector3 currentVelocity = Vector3.zero; // Для сглаживания движения
    private bool isPointerOver = false;

    private Camera mainCamera; // Главная камера

    void Start()
    {
        initialPosition = transform.position; // Сохраняем начальную позицию панели в мировых координатах
        mainCamera = Camera.main; // Находим главную камеру
    }

    void Update()
    {
        Vector3 targetPosition = isPointerOver ? GetTargetPosition() : initialPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        Debug.Log($"Current position: {transform.position}, Target position: {targetPosition}, isPointerOver: {isPointerOver}");
    }

    private Vector3 GetTargetPosition()
    {
        // Вычисляем направление от панели к камере
        Vector3 directionToCamera = (mainCamera.transform.position - initialPosition).normalized;

        // Ограничиваем расстояние
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
