using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChangeSkybox : MonoBehaviour
{
    [Header("Type Skybox")]
    [SerializeField] private string skyboxAddress;

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
            ErrorType.UnknownError.LogCustomError("Адрес ассета скайбокса не задан");
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
                ErrorType.UnknownError.LogCustomError("Загруженный материал скайбокса равен null");
            }
        }
        else
        {
            ErrorType.UnknownError.LogCustomError("Не удалось загрузить материал скайбокса по адресу: " + skyboxAddress);
        }
    }
}
