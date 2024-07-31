using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;

    private Button continueButton;

    private List<string> contentList;

    private int contentIdx;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        nameText = transform.Find("NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        this.contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        Hide();
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(string npcName, string[] content)
    {
        nameText.text = npcName;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIdx = 0;
        contentText.text = contentList[0];
        gameObject.SetActive(true);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnContinueButtonClick()
    {
        contentIdx++;
        if (contentIdx >= contentList.Count)
        {
            Hide();
            return;
        }

        contentText.text = contentList[contentIdx];
    }
}