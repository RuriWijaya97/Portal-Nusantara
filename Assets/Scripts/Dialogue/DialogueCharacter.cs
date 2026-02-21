using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueCharacter : MonoBehaviour
{
    public TMP_Text CharacterNameLabel;
    public TMP_Text ConversationTextLabel;
    public GameObject DialoguePanel;

    public string CharacterName;
    [TextArea] public string[] ConversationText;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        CharacterNameLabel.text = CharacterName;
        ConversationTextLabel.text = ConversationText[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if (index < ConversationText.Length)
            {
                ConversationTextLabel.text = ConversationText[index];
            }
            else
            {
                index = 0;
                DialoguePanel.SetActive(false);
                ConversationTextLabel.text = ConversationText[index];
            }

        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            DialoguePanel.SetActive(true);
        }
    }
}
