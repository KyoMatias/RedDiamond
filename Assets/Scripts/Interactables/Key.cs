using ScriptableObjectArchitecture;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private StringGameEvent _onPlayerPicksUpKey;

    public override void Interact()
    {
        base.Interact();

        _onPlayerPicksUpKey.Raise(_name);

        gameObject.SetActive(false);
    }
}
