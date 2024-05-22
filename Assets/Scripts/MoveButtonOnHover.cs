using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    public float moveDistance = 50f;
    public float moveSpeed = 10f;
    public float returnSpeed = 5f;

    private Vector3 initialPosition;
    private bool isMoved = false;

    void Start()
    {
        initialPosition = transform.position;
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        if (isMoved)
        {
            Vector3 targetPosition = initialPosition + Vector3.forward * moveDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoved = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
            if (transform.position == initialPosition)
            {
                isMoved = false;
            }
        }
    }

    public void OnButtonClick()
    {
        if (!isMoved)
        {
            if (transform.position == initialPosition)
            {
                isMoved = true;
            }
            else
            {
                isMoved = false;
            }
        }
    }
}
