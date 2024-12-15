using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorPresenter : ICalculatorPresenter
{
    private readonly ICalculatorViewer viewer;
    private SaveLoadManager saveLoadManager;
    public CalculatorPresenter(ICalculatorViewer _viewer)
    {
        viewer = _viewer;
        saveLoadManager = new SaveLoadManager();
        LoadData();
    }
    public void OnCalculateButtonClicked(string _expression)
    {
        if (CalculatorModel.TryCalculate(_expression, out var result))
        {
            string equality = _expression + "=" + result.ToString();
            viewer.ShowResult(equality);
        }
        else
        {
            string error = "Please check the expression you just entered";
            viewer.ShowError(error);
        }
    }
    public void Exit() => SaveData();
    public void SaveData()
    {
        SaveData data = new SaveData();
        data.currentExpression = viewer.GetDataToSave().Item1;
        data.history = viewer.GetDataToSave().Item2;
        saveLoadManager.Save(data);
    }
    public void LoadData()
    {
        SaveData data = saveLoadManager.Load();
        viewer.SetCurrentInput(data.currentExpression);
        foreach (var equality in data.history) viewer.UpdateArchive(equality);
    }
}


