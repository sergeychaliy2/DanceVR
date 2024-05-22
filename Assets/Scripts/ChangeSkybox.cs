using UnityEngine;
using UnityEngine.UI;

public class ChangeSkybox : MonoBehaviour
{
    // ���������� ��� �������� ������ skybox ���������
    public Material newSkyboxMaterial;

    void Start()
    {
        // �������� ��������� Button �� ���� �������
        Button button = GetComponent<Button>();

        // ��������� ��������� ��� ������� ������� ������
        if (button != null)
        {
            button.onClick.AddListener(ChangeSkyboxMaterial);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    // ����� ��� ����� skybox ���������
    public void ChangeSkyboxMaterial()
    {
        if (newSkyboxMaterial != null)
        {
            RenderSettings.skybox = newSkyboxMaterial;
            // ��������� ��������� �����, ���� ��� ����������
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            Debug.LogError("New Skybox Material is not assigned.");
        }
    }
}
