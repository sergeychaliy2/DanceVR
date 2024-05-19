using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // �������� �������� �������
    private Vector3 initialPosition;
    private float timer = 0f;
    private const float positionUpdateInterval = 15f; // �������� ���������� ��������� �������

    void Start()
    {
        // ��������� ��������� ������� �������
        initialPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= positionUpdateInterval)
        {
            // ��������� ��������� ������� �������
            initialPosition = transform.position;
            timer = 0f; // ���������� ������
        }

        RotateTowardsCamera();
    }

    void RotateTowardsCamera()
    {
        // ���������, ��� ���� �������� ������
        if (Camera.main != null)
        {
            // ������� ����������� ������ �� �������
            Vector3 direction = Camera.main.transform.position - initialPosition;
            direction.y = 0f; // ������������ �������� ������ �� �����������

            // �������� ������� ������� �� ���� ����
            transform.position = initialPosition;

            // ������� ����������� ������� ������ � �������
            Quaternion rotation = Quaternion.LookRotation(direction);

            // ������ ������������ ������ � ������
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Main camera is not found in the scene.");
        }
    }
}
