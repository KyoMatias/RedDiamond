using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    string name;

    private void OnEnable()
    {
        KeyHolder.OnGetKey += Interact;
    }

    private void Interact(string name)
    {

    }
}
