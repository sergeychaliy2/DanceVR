using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    public GameObject sceneAnimator; // ���� ��� �������� ������� SceneAnimator ����� ���������
    public string nameFile;
    [SerializeField]
    private string filePath = "AnimPref/";
    private string path;

    // ����� ��� �������� � �������� �������
    public void LoadAndAttachPrefab()
    {
        path = filePath + nameFile;
        // ��������� ������ �� ����� Resources/AnimPref
        GameObject prefab = Resources.Load<GameObject>(path);

        // ���������, ��� ������ ������� ��������
        if (prefab == null)
        {
            Debug.LogError("Prefab '" + path + "' �� ������ �� ���� 'Resources/AnimPref/'");
            return;
        }

        // ���������, ��� ������ SceneAnimator ������� ����� ���������
        if (sceneAnimator == null)
        {
            Debug.LogError("������ SceneAnimator �� ��� ������� ����� ���������");
            return;
        }

        // �������� ��������� ������� � �������� ��� �������� ��������� ������� SceneAnimator
        GameObject instance = Instantiate(prefab, sceneAnimator.transform);

        // ��������� rotation � scale ������� ��� ��� ����������
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = prefab.transform.localRotation; // ��������� rotation �������
        instance.transform.localScale = prefab.transform.localScale; // ��������� scale �������
    }
}
