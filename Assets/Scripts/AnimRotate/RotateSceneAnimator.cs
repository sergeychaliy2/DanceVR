using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Скорость вращения объекта
    private Vector3 initialPosition;
    private float timer = 0f;
    private const float positionUpdateInterval = 10f; // Интервал обновления начальной позиции в секундах

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
        // Проверяем, что основная камера существует
        if (Camera.main != null)
        {
            // Вычисляем направление от объекта к камере
            Vector3 direction = Camera.main.transform.position - transform.position;
            direction.y = 0f; // Ограничиваем вращение только по горизонтали

            // Сохраняем текущие координаты объекта по осям X и Z
            Vector3 currentPosition = transform.position;
            currentPosition.x = initialPosition.x;
            currentPosition.z = initialPosition.z;
            transform.position = currentPosition;

            // Вычисляем необходимый поворот объекта к камере
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Плавно поворачиваем объект к камере
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Основная камера не найдена в сцене.");
        }
    }
}
