using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICalculatorViewer
{
    void ShowResult(string _result);
    void ShowError(string _errorMessage);
    void SetCurrentInput(string _currentInput);
    void UpdateArchive(string _equality);
    (string, List<string>) GetDataToSave();
}
