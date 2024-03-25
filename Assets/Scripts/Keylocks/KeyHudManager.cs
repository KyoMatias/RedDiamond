using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHudManager : MonoBehaviour
{
    public RedKey redKey {
        get {return FindObjectOfType<RedKey>();}
    }
    public static KeyHudManager Instance {get; private set;}
    public int RedKeyCount {get; private set;}


    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        redKey.OnTurnCount += HandleChangeTurn;
    }

    void HandleChangeTurn(int value)
    {
        
        Debug.Log($"Turn Count: {value}");
    }
}
