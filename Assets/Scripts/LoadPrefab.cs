using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadPrefab : MonoBehaviour
{
    [Header("Load Scene Animator")]
    [Space]
    [SerializeField] private GameObject sceneAnimator;
    [SerializeField] private string address;

    public void LoadAndAttachPrefab()
    {
        if (string.IsNullOrEmpty(address))
        {
            ErrorType.UnknownError.LogCustomError("Адрес ассета не задан");
            return;
        }

        if (sceneAnimator == null)
        {
            ErrorType.UnknownError.LogCustomError("Объект SceneAnimator не был передан через инспектор");
            return;
        }

        DeleteAllPrefObjects();

        Addressables.LoadAssetAsync<GameObject>(address).Completed += OnPrefabLoaded;
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = obj.Result;
            GameObject instance = Instantiate(prefab, sceneAnimator.transform);
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = prefab.transform.localRotation;
            instance.transform.localScale = prefab.transform.localScale;
        }
        else
        {
            ErrorType.UnknownError.LogCustomError("Не удалось загрузить префаб по адресу: " + address);
        }
    }

    private void DeleteAllPrefObjects()
    {
        GameObject[] prefObjects = GameObject.FindGameObjectsWithTag("Pref");
        foreach (GameObject obj in prefObjects)
        {
            Destroy(obj);
        }
    }
}
