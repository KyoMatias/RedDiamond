using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : KeyRotator
{
    public Action<int> OnTurnCount;
    private int _currentTurns;


    private void Awake() {
        _currentTurns = 0;
    }
        public override void RotateR()
        {
        base.RotateR();
        ChangeCount(1);
        }

    public override void RotateL()
    {
        base.RotateL();
        ChangeCount(-1);
    }


    public void ChangeCount(int amount)
    {
        _currentTurns += amount;
        if(OnTurnCount != null) OnTurnCount(_currentTurns);
        
    }
}
