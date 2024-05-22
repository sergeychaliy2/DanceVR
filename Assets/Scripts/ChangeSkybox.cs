using UnityEngine;
using UnityEngine.UI;

public class ChangeSkybox : MonoBehaviour
{
    // Переменная для хранения нового skybox материала
    public Material newSkyboxMaterial;

    void Start()
    {
        // Получаем компонент Button на этом объекте
        Button button = GetComponent<Button>();

        // Добавляем слушатель для события нажатия кнопки
        if (button != null)
        {
            button.onClick.AddListener(ChangeSkyboxMaterial);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    // Метод для смены skybox материала
    public void ChangeSkyboxMaterial()
    {
        if (newSkyboxMaterial != null)
        {
            RenderSettings.skybox = newSkyboxMaterial;
            // Обновляем параметры среды, если это необходимо
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            Debug.LogError("New Skybox Material is not assigned.");
        }
    }
}
