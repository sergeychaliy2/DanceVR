using UnityEngine;

public class ResetTransform : MonoBehaviour
{
    // ����� Start ���������� ���� ��� ��� ������������� �������
    void Start()
    {
        // ����� ������� �� (0, 0, 0)
        transform.position = Vector3.zero;

        // ��������� �������: 180 �������� �� ��� Y
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
