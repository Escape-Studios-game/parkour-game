using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Default class for the creation
/// </summary>
[RequireComponent(typeof(Canvas))]
public class UiController : MonoBehaviour
{
    private Canvas _canvas;

    private void Awake() => _canvas = GetComponent<Canvas>();

    /// <summary>
    ///  Shows all elements from the UI
    /// </summary>
    public void ShowUi() => _canvas.enabled = true;

    /// <summary>
    /// Hides all elements from the UI
    /// </summary>
    public void HideUi() => _canvas.enabled = false;

    /// <summary>
    /// Changes the text from
    /// </summary>
    /// <param name="gameObjectName"></param>
    /// <param name="toSet"></param>
    public void SetText(string gameObjectName, string toSet)
    {
        var child = transform.Find(gameObjectName);

        if (child == null)
        {
            GameObjectNotFound(gameObjectName);
            return;
        }

        if (child.TryGetComponent<TextMeshProUGUI>(out var tmpText))
        { tmpText.text = toSet; }
        else
        { Debug.LogWarning($"GameObject '{gameObjectName}' has no TextMeshProUGUI component."); }
    }

    /// <summary>
    /// Changes the image from a sprite
    /// </summary>
    /// <param name="gameObjectName"></param>
    /// <param name="toSet"></param>
    public void SetImageSprite(string gameObjectName, Sprite toSet)
    {
        if (transform.Find(gameObjectName).TryGetComponent<Image>(out var img))
        {
            img.sprite = toSet;
        }
        else
        { GameObjectNotFound(gameObjectName); }
    }

    /// <summary>
    /// Changes the value form a Slider
    /// </summary>
    /// <param name="gameObjectName"></param>
    /// <param name="value"></param>
    public void SetSliderValue(string gameObjectName, float value)
    {
        if (transform.Find(gameObjectName).TryGetComponent<Slider>(out var slider))
        { slider.value = value; }
        else
        { GameObjectNotFound(gameObjectName); }
    }

    private void GameObjectNotFound(string gameObjectName) => Debug.LogWarning($"No GameObject found with name '{gameObjectName}'. Is it a child of this GameObject?");
}
