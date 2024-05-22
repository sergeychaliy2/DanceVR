using UnityEngine;
using UnityEngine.UI;

public class ChangeSkybox : MonoBehaviour
{
    public Material newSkyboxMaterial;

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
        if (newSkyboxMaterial != null)
        {
            RenderSettings.skybox = newSkyboxMaterial;
            DynamicGI.UpdateEnvironment();
        }
    }
}
