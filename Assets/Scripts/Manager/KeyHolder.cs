using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public static event Action<string> OnGetKey;

    private List<string> m_keyNames = new List<string>();

    private void OnEnable()
    {
        OnGetKey += AddKey;
    }

    private void Update()
    {
        OnGetKey?.Invoke(name);
    }

    private void AddKey(string keyName)
    {
        m_keyNames.Add(keyName);
    }
}
