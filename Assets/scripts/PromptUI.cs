using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptUI : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;

    public bool IsDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public void SetUp(string text)
    {
        promptText.text = text;
        uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
