using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    public float moveDistance = 50f;
    public float moveSpeed = 10f;
    public float returnSpeed = 5f; // Скорость возвращения кнопки

    private Vector3 initialPosition;
    private bool isMoved = false;

    void Start()
    {
        // Запоминаем начальную позицию кнопки
        initialPosition = transform.position;

        // Назначаем метод OnButtonClick() на событие нажатия на кнопку
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        // Если кнопка в процессе движения
        if (isMoved)
        {
            // Вычисляем новую позицию кнопки, относительно её начальной позиции
            Vector3 targetPosition = initialPosition + Vector3.forward * moveDistance;

            // Двигаем кнопку к новой позиции с заданной скоростью
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Если кнопка достигла целевой позиции
            if (transform.position == targetPosition)
            {
                // Перестаем двигать кнопку
                isMoved = false;
            }
        }
        else // Если кнопка в процессе возвращения
        {
            // Двигаем кнопку обратно к начальной позиции с меньшей скоростью
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

            // Если кнопка вернулась на начальную позицию
            if (transform.position == initialPosition)
            {
                // Сбрасываем переменные состояния
                isMoved = false;
            }
        }
    }

    public void OnButtonClick()
    {
        // Если кнопка не двигается, то начинаем движение
        if (!isMoved)
        {
            // Если кнопка находится в начальной позиции, двигаем ее
            if (transform.position == initialPosition)
            {
                isMoved = true;
            }
            // Иначе, если кнопка уже была двинута, возвращаем ее обратно
            else
            {
                isMoved = false;
            }
        }
    }
}
