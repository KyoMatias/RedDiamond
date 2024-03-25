using ScriptableObjectArchitecture;
using UnityEngine;

public class Lock : Interactable
{
    [SerializeField] private StringGameEvent _canPlayerOpenLock;

    public override void Interact()
    {
        base.Interact();

        _canPlayerOpenLock.Raise(_name);
    }
}
