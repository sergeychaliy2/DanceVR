using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        ErrorType.OperationFailed.Log();

        //ErrorType.UnknownError.LogCustomError("A custom unknown error occurred.");
    }
}
