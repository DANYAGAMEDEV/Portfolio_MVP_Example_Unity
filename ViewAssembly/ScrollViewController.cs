using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollViewController : MonoBehaviour
{
    [SerializeField] private RectTransform scrollView, inputPanel, content;
    [SerializeField] private GameObject scroll, prefab;

    public void AddElement(string _inputText)
    {
        GameObject element = Instantiate(prefab, content);
        element.transform.SetAsFirstSibling();
        element.GetComponent<TextMeshProUGUI>().text = _inputText;
        UpdateScrollViewSize();
    }
    private void  UpdateScrollViewSize()
    {
        int childCount = content.childCount;
        scroll.SetActive(childCount > 3);
        int maxElementsVisibility = 7;
        int elemetnSize = 20;
        childCount = Mathf.Clamp(childCount, 0, maxElementsVisibility);
        float sizeDelta = elemetnSize * childCount;

        scrollView.sizeDelta = new Vector2(scrollView.sizeDelta.x, sizeDelta);
        scrollView.anchoredPosition = new Vector2(scrollView.anchoredPosition.x, 0 - sizeDelta / 2);
        inputPanel.sizeDelta = new Vector2(inputPanel.sizeDelta.x, 150 + sizeDelta);
        inputPanel.anchoredPosition = new Vector2(inputPanel.anchoredPosition.x, 0 - sizeDelta / 2);
    }
  
}
