using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorViewer : MonoBehaviour, ICalculatorViewer
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button resultButton, gotItButton;
    [SerializeField] private GameObject errorPanel, inputPanel;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private ScrollViewController scrollViewController;
    private ICalculatorPresenter presenter;
    private string currentInput;
    [SerializeField] private List<string> history = new List<string>();

    private void Awake()
    {
        resultButton.onClick.AddListener(OnResultButtonClicked);
        gotItButton.onClick.AddListener(OnGotItButtonClicked);
        inputField.onValueChanged.AddListener(SetCurrentInput);
    }
    public void SetPresenter(ICalculatorPresenter _presenter) => presenter = _presenter;
    private void OnResultButtonClicked()
    {
        currentInput = inputField.text;
        presenter.OnCalculateButtonClicked(currentInput);
    }
    private void OnGotItButtonClicked()
    {
        SetCurrentInput(currentInput);
        errorPanel.SetActive(false);
        inputPanel.SetActive(true);
    }
    public void ShowResult(string _result)
    {
        inputField.text = _result;
        UpdateArchive(_result);
    }
    public void ShowError(string _errorMessage)
    {
        errorPanel.SetActive(true);
        inputPanel.SetActive(false);
        errorText.text = _errorMessage;
        UpdateArchive(currentInput + "=ERROR");
    }
    public void UpdateArchive(string _equality)
    {
        scrollViewController.AddElement(_equality);
        history.Add(_equality);
    }
    public void SetCurrentInput(string _currentInput)
    {
        currentInput = _currentInput;
        inputField.text = _currentInput;
    }
    public (string, List<string>) GetDataToSave()
    {
        return (currentInput, history);
    }

}
