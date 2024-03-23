using ScriptableObjectArchitecture;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected private string _name;

    [SerializeField] private StringGameEvent _onGrabInteractableObjectName;

    public virtual void Interact() { }

    public virtual void GrabInteractableObjectName()
    {
        _onGrabInteractableObjectName.Raise(_name);
    }

}
