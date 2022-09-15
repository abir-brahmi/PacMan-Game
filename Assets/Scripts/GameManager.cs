using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int _dotAmount = 149 ;

    private void Awake()
    {
        instance = this;
    }

    public void AddDot()
    {
        _dotAmount++;
    }

    public void DeleteDot()
    {
        _dotAmount--;
        if (_dotAmount <= 0)
        {
            //Win
        }
    }
    
}
