using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSaver : MonoBehaviour
{
    //GUI interation for saving high scores after game onto a text file
    public HighScoreBoard highScoreBoard;
    
    public TMP_Text playerScoreText;
    public TMP_InputField playerNameInput;
    public Button saveScoreButton;

    public FloatSO playerScore;

    private bool hasSaved = false;
    void Start()
    {
        playerScoreText.text = "Score: " + (int)playerScore.value;

        saveScoreButton.onClick.AddListener(OnSaveClicked);
        saveScoreButton.interactable = false;

        playerNameInput.characterLimit = 3;
        playerNameInput.onValueChanged.AddListener(OnNameChanged);
    }

    void OnSaveClicked()
    {
        hasSaved = true;
        saveScoreButton.interactable = false;
        highScoreBoard.AddHighScore(playerNameInput.text, (int)playerScore.value);
    }

    void OnNameChanged(string name)
    {
        saveScoreButton.interactable = !hasSaved && name.Length > 0;
    }
    
    
}