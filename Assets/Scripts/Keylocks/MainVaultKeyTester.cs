using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVaultKeyTester : MonoBehaviour
{
    [SerializeField] private GameObject redkey;
    [SerializeField] private GameObject yellowkey;
    [SerializeField] private GameObject blackKey;


    public void OnRed()
    {
        Debug.Log("Red Key Clicked");
    }
}
