using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadPrefab : MonoBehaviour
{
    public GameObject sceneAnimator;
    public string address; // Адрес, используемый для загрузки ассета

    public void LoadAndAttachPrefab()
    {
        if (string.IsNullOrEmpty(address))
        {
            Debug.LogError("Адрес ассета не задан");
            return;
        }

        if (sceneAnimator == null)
        {
            Debug.LogError("Объект SceneAnimator не был передан через инспектор");
            return;
        }

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
            Debug.LogError("Failed to load prefab at address: " + address);
        }
    }
}
