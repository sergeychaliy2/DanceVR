using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    public GameObject sceneAnimator; // Поле для передачи объекта SceneAnimator через инспектор
    public string nameFile;
    [SerializeField]
    private string filePath = "AnimPref/";
    private string path;

    // Метод для загрузки и создания префаба
    public void LoadAndAttachPrefab()
    {
        path = filePath + nameFile;
        // Загрузите префаб из папки Resources/AnimPref
        GameObject prefab = Resources.Load<GameObject>(path);

        // Убедитесь, что префаб успешно загружен
        if (prefab == null)
        {
            Debug.LogError("Prefab '" + path + "' не найден по пути 'Resources/AnimPref/'");
            return;
        }

        // Убедитесь, что объект SceneAnimator передан через инспектор
        if (sceneAnimator == null)
        {
            Debug.LogError("Объект SceneAnimator не был передан через инспектор");
            return;
        }

        // Создайте экземпляр префаба и сделайте его дочерним элементом объекта SceneAnimator
        GameObject instance = Instantiate(prefab, sceneAnimator.transform);

        // Сохраняем rotation и scale префаба для его экземпляра
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = prefab.transform.localRotation; // сохраняем rotation префаба
        instance.transform.localScale = prefab.transform.localScale; // сохраняем scale префаба
    }
}
