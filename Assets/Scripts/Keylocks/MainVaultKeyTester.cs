using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVaultKeyTester : MonoBehaviour
{
    [SerializeField] private GameObject redkey;
    [SerializeField] private GameObject yellowkey;
    [SerializeField] private GameObject blackKey;


    private void Awake() {
        redkey.SetActive(false);
        yellowkey.SetActive(false);
        blackKey.SetActive(false);
    }


    public void OnRed()
    {
        redkey.SetActive(true);
        Debug.Log("Red Key Clicked");
    }
    public void OnYellow()
    {
        yellowkey.SetActive(true);
        Debug.Log("Yellow Key Clicked");
    
    }

    public void OnBlack()
    {
        blackKey.SetActive(true);
        Debug.Log("BlackKeyClicked");
    }
}
