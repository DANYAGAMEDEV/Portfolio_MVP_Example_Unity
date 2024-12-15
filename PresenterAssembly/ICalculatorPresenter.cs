using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICalculatorPresenter  
{
    void OnCalculateButtonClicked(string _expression);
    void SaveData();
    void LoadData();
}
