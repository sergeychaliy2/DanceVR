using UnityEngine;

public class ResetTransform : MonoBehaviour
{
    // Метод Start вызывается один раз при инициализации скрипта
    void Start()
    {
        // Сброс позиции на (0, 0, 0)
        transform.position = Vector3.zero;

        // Установка ротации: 180 градусов по оси Y
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
