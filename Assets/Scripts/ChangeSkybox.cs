using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChangeSkybox : MonoBehaviour
{
    [Header("Type Skybox")]
    [SerializeField] private string skyboxAddress;

    private IErrorHandler errorHandler;
    private IAssetLoader assetLoader;

    private void Awake()
    {
        errorHandler = new ErrorHandler();
        assetLoader = new AssetLoader();
    }

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeSkyboxMaterial);
        }
        else
        {
            errorHandler.LogCustomError(ErrorType.UnknownError, "Button component is missing.");
        }
    }

    public void ChangeSkyboxMaterial()
    {
        if (!string.IsNullOrEmpty(skyboxAddress))
        {
            AsyncOperationHandle<Material> handle = assetLoader.LoadAssetAsync<Material>(skyboxAddress);
            handle.Completed += OnSkyboxLoaded;
        }
        else
        {
            errorHandler.LogCustomError(ErrorType.UnknownError, "Skybox asset address is not set.");
        }
    }

    private void OnSkyboxLoaded(AsyncOperationHandle<Material> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Material newSkyboxMaterial = handle.Result;
            if (newSkyboxMaterial != null)
            {
                RenderSettings.skybox = newSkyboxMaterial;
                DynamicGI.UpdateEnvironment();
            }
            else
            {
                errorHandler.LogCustomError(ErrorType.UnknownError, "Loaded skybox material is null.");
            }
        }
        else
        {
            errorHandler.LogCustomError(ErrorType.UnknownError, $"Failed to load skybox material from address: {skyboxAddress}");
        }
    }
}
