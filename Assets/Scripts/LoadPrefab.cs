using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

public class LoadPrefab : MonoBehaviour
{
    [Header("Load Scene Animator")]
    [Space]
    [SerializeField] private GameObject sceneAnimator;
    [SerializeField] private string address;

    private List<GameObject> instantiatedPrefabs = new List<GameObject>();

    public void LoadAndAttachPrefab()
    {
        if (string.IsNullOrEmpty(address))
        {
            ErrorType.UnknownError.LogCustomError("Asset address is not set.");
            return;
        }

        if (sceneAnimator == null)
        {
            ErrorType.UnknownError.LogCustomError("SceneAnimator object not assigned in the inspector.");
            return;
        }

        DeleteAllPrefObjects();

        Addressables.LoadAssetAsync<GameObject>(address).Completed += OnPrefabLoaded;
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = handle.Result;
            if (prefab != null)
            {
                GameObject instance = Instantiate(prefab, sceneAnimator.transform);
                instance.transform.localPosition = Vector3.zero;
                instance.transform.localRotation = prefab.transform.localRotation;
                instance.transform.localScale = prefab.transform.localScale;
                instantiatedPrefabs.Add(instance);
            }
            else
            {
                ErrorType.UnknownError.LogCustomError("Loaded prefab is null.");
            }
        }
        else
        {
            ErrorType.UnknownError.LogCustomError("Failed to load prefab from address: " + address);
        }
    }

    private void DeleteAllPrefObjects()
    {
        foreach (GameObject obj in instantiatedPrefabs)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        instantiatedPrefabs.Clear();
    }
}
