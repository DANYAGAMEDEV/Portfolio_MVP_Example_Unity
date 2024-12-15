using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppSystem : MonoBehaviour
{
 
    [SerializeField] private CalculatorViewer viewer;
    private CalculatorPresenter calculatorPresenter;

    private void Start() => InitializeCalculatorApp();
    private void OnApplicationQuit() => calculatorPresenter.Exit();
    private void InitializeCalculatorApp()
    {
        calculatorPresenter = new CalculatorPresenter(viewer);
        viewer.SetPresenter(calculatorPresenter);
    }
  

}


