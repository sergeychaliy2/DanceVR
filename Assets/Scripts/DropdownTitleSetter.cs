using UnityEngine;
using TMPro; // ���������� ������������ ���� ��� ������ � TextMeshPro
using Nova.TMP;

public class ChangeTMPTextBlockOnStart : MonoBehaviour
{
    [SerializeField] private TextMeshProTextBlock tmpTextBlock; // ������ �� TextMeshProTextBlock ���������
    [SerializeField] private string newText = "��� ����� �����"; // ����� ����� ��� �����������

    void Start()
    {
        if (tmpTextBlock != null)
        {
            tmpTextBlock.text = newText; // �����������, ��� ��� ��������� ����� �������� text
        }
        else
        {
            Debug.LogWarning("TextMeshProTextBlock ��������� �� ��������.");
        }
    }
}
