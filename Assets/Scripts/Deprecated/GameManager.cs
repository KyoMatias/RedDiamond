using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private KyoCollision _kyoColl
    {
        get {return FindObjectOfType<KyoCollision>();}
    }

    public static GameManager Instance {get; private set;}

    private void Awake() 
    {
        if(Instance == null )
        {
            Instance = this;
        }
        else if (Instance != this )
        {
            Destroy(this);
        }

        _kyoColl.OnDetectObject += DetectKey;
    }


    void DetectKey()
    {
        Debug.Log("Detected a Key");
    }


}
