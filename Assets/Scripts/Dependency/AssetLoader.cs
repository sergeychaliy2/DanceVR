using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public interface IAssetLoader
{
    AsyncOperationHandle<T> LoadAssetAsync<T>(string address) where T : class;
}
public class AssetLoader : IAssetLoader
{
    public AsyncOperationHandle<T> LoadAssetAsync<T>(string address) where T : class
    {
        return Addressables.LoadAssetAsync<T>(address);
    }
}