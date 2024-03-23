using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private List<string> _obtainedKeys = new List<string>();

    [SerializeField] private GameEvent _onPlayerOpensLock;
 
    public void PickUpKey(string keyName)
    {
        _obtainedKeys.Add(keyName);
    }

    public void CheckForKey(string lockName)
    {
        if (_obtainedKeys.Contains(lockName))
        {
            _onPlayerOpensLock.Raise();
        }
    }
}
