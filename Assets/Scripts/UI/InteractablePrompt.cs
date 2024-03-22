using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class InteractablePrompt : MonoBehaviour
{
    [SerializeField] private GameObject _interactablePrompt;
    [SerializeField] private TextMeshProUGUI _interactableName;

    public void ShowPrompt(bool flag)
    {
        _interactablePrompt.SetActive(flag);
    }

    public void ChangeInteractableName(string name)
    {
        _interactableName.text = $"\"{name}\"";

    }
}
