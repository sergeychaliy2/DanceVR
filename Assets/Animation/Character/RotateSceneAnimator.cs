using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Скорость вращения объекта
    private Vector3 initialPosition;
    private float timer = 0f;
    private const float positionUpdateInterval = 15f; // Интервал обновления начальной позиции

    void Start()
    {
        // Сохраняем начальную позицию объекта
        initialPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= positionUpdateInterval)
        {
            // Обновляем начальную позицию объекта
            initialPosition = transform.position;
            timer = 0f; // Сбрасываем таймер
        }

        RotateTowardsCamera();
    }

    void RotateTowardsCamera()
    {
        // Проверяем, что есть основная камера
        if (Camera.main != null)
        {
            // Находим направление камеры от объекта
            Vector3 direction = Camera.main.transform.position - initialPosition;
            direction.y = 0f; // Ограничиваем вращение только по горизонтали

            // Обнуляем позицию объекта по всем осям
            transform.position = initialPosition;

            // Находим необходимый поворот камеры к объекту
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Плавно поворачиваем объект к камере
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Main camera is not found in the scene.");
        }
    }
}
