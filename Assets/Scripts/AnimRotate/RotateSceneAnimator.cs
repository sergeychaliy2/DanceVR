using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    public float rotationSpeed = 1.0f; 
    private Vector3 initialPosition;
    private float timer = 0f;
    private const float positionUpdateInterval = 10f; 

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= positionUpdateInterval)
        {
            initialPosition = transform.position;
            timer = 0f; 
        }

        RotateTowardsCamera();
    }

    void RotateTowardsCamera()
    {
        if (Camera.main != null)
        {
            Vector3 direction = Camera.main.transform.position - transform.position;
            direction.y = 0f;
            Vector3 currentPosition = transform.position;
            currentPosition.x = initialPosition.x;
            currentPosition.z = initialPosition.z;
            transform.position = currentPosition;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Основная камера не найдена в сцене.");
        }
    }
}
