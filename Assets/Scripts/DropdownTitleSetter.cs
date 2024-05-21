using UnityEngine;
using TMPro; // Подключаем пространство имен для работы с TextMeshPro
using Nova.TMP;

public class ChangeTMPTextBlockOnStart : MonoBehaviour
{
    [SerializeField] private TextMeshProTextBlock tmpTextBlock; // Ссылка на TextMeshProTextBlock компонент
    [SerializeField] private string newText = "Ваш новый текст"; // Новый текст для отображения

    void Start()
    {
        if (tmpTextBlock != null)
        {
            tmpTextBlock.text = newText; // Предположим, что ваш компонент имеет свойство text
        }
        else
        {
            Debug.LogWarning("TextMeshProTextBlock компонент не назначен.");
        }
    }
}
