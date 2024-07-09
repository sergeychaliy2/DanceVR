using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChangeSkybox : MonoBehaviour
{
    public string skyboxAddress;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeSkyboxMaterial);
        }
    }

    public void ChangeSkyboxMaterial()
    {
        if (!string.IsNullOrEmpty(skyboxAddress))
        {
            Addressables.LoadAssetAsync<Material>(skyboxAddress).Completed += OnSkyboxLoaded;
        }
        else
        {
            Debug.LogError("Адрес ассета скайбокса не задан");
        }
    }

    private void OnSkyboxLoaded(AsyncOperationHandle<Material> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Material newSkyboxMaterial = obj.Result;
            if (newSkyboxMaterial != null)
            {
                RenderSettings.skybox = newSkyboxMaterial;
                DynamicGI.UpdateEnvironment();
            }
            else
            {
                Debug.LogError("Загруженный материал скайбокса равен null");
            }
        }
        else
        {
            Debug.LogError("Не удалось загрузить материал скайбокса по адресу: " + skyboxAddress);
        }
    }
}
