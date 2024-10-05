using UnityEngine;
using UnityEngine.UIElements;

public class Exit : MonoBehaviour
{
    public UIDocument uiDocument;
    private VisualElement root;
    private VisualElement blackScreen;

    void Start()
    {
        root = uiDocument.rootVisualElement;
        blackScreen = root.Q<VisualElement>("BlackScreen");
    }

    void OnTriggerEnter(Collider collider)
    {
        blackScreen.RemoveFromClassList("hide");
    }
}
