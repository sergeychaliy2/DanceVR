using UnityEngine;
using TMPro;
using Nova.TMP;

public class ChangeTMPTextBlockOnStart : MonoBehaviour
{
    [SerializeField] private TextMeshProTextBlock tmpTextBlock;
    [SerializeField] private string newText = "Ваш новый текст";

    void Start()
    {
        if (tmpTextBlock != null)
        {
            tmpTextBlock.text = newText;
        }
        else
        {
            Debug.LogWarning("TextMeshProTextBlock компонент не назначен.");
        }
    }
}
