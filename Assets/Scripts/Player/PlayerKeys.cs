using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private List<string> _obtainedKeys = new List<string>();

    public void PickUpKey(string keyName)
    {
        _obtainedKeys.Add(keyName);
    }
}
