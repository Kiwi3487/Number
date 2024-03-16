using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] int answer;
    [SerializeField] private TMP_Text feedback;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button submit;
    [SerializeField] private Button next;
    public FloatSO playerScore;

    int number;
    void Start()
    {
        input.onValueChanged.AddListener((OnGuessChanged));
        submit.onClick.AddListener(OnSubmit);

        submit.interactable = false;
        next.interactable = false;
    }

    void OnGuessChanged(string guessString)
    {
        bool success = int.TryParse(guessString, out number);
        if (success && !next.interactable)
        {
            feedback.text = "Confirmed?";
            submit.interactable = true;
        }
        else
        {
            feedback.text = "Enter a number";
            submit.interactable = false;
        }
    }

    void OnSubmit()
    {
        if (answer == number)
        {
            feedback.text = "Correct!";
            feedback.color = Color.green;
            playerScore.value++;
        }
        else
        {
            feedback.text = "Incorrect";
            feedback.color = Color.red;
        }

        submit.interactable = false;
        next.interactable = true;
    }
    
}