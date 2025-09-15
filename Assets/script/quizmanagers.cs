using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class quizmanagers : MonoBehaviour
// {
//     [System.Serializable]
//     public class Question
//     {
//         public string questionText;
//         public string[] choices;
//         public int correctIndex;
//     }

//     public TextMeshProUGUI questionText;
//     public TextMeshProUGUI[] choiceTexts;
//     public Button[] choiceButtons;

//     public GameObject resultPanel;
//     public TextMeshProUGUI scoreText;

//     public Question[] questions;
//     public AudioSource clickSound;

//     private int currentIndex = 0;
//     private int score = 0;

//     void Start()
//     {
//         resultPanel.SetActive(false);
//         ShowQuestion();
//     }

//     void ShowQuestion()
//     {
//         Question q = questions[currentIndex];
//         questionText.text = q.questionText;

//         for (int i = 0; i < choiceButtons.Length; i++)
//         {
//             choiceTexts[i].text = q.choices[i];
//             int choice = i;
//             choiceButtons[i].onClick.RemoveAllListeners();
//             choiceButtons[i].onClick.AddListener(() => CheckAnswer(choice));
//         }
//     }

//     void OnAnswerClicked(int choice)
//     {
//         // 🔊 Play click sound
//         if (clickSound != null) clickSound.Play();

//         CheckAnswer(choice);
//     }

//     void CheckAnswer(int choice)
//     {
//         if (choice == questions[currentIndex].correctIndex)
//             score++;

//         currentIndex++;

//         if (currentIndex < questions.Length)
//             ShowQuestion();
//         else
//             EndQuiz();
//     }

//     void EndQuiz()
//     {
//         questionText.gameObject.SetActive(false);
//         foreach (var btn in choiceButtons)
//             btn.gameObject.SetActive(false);

//         resultPanel.SetActive(true);
//         scoreText.text = "Your Score: " + score + "/" + questions.Length;

//         PlayerPrefs.SetInt("LastScore", score);
//         PlayerPrefs.Save();
//     }

//     public void RestartQuiz()
//     {
//         if (clickSound != null) clickSound.Play();
//         UnityEngine.SceneManagement.SceneManager.LoadScene("pickleball quiz");
//     }
// }

{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] choices;
        public int correctIndex;
    }

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] choiceTexts;
    public Button[] choiceButtons;

    public GameObject resultPanel;
    public TextMeshProUGUI scoreText;

    public Question[] questions;

    public AudioSource clickSound; // 🔊 Add this

    private int currentIndex = 0;
    private int score = 0;

    void Start()
    {
        resultPanel.SetActive(false);
        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question q = questions[currentIndex];
        questionText.text = q.questionText;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceTexts[i].text = q.choices[i];
            int choice = i;
            choiceButtons[i].onClick.RemoveAllListeners();
            choiceButtons[i].onClick.AddListener(() => OnAnswerClicked(choice));
        }
    }

    void OnAnswerClicked(int choice)
    {
        // 🔊 Play click sound
        if (clickSound != null) clickSound.Play();

        CheckAnswer(choice);
    }

    void CheckAnswer(int choice)
    {
        if (choice == questions[currentIndex].correctIndex)
            score++;

        currentIndex++;

        if (currentIndex < questions.Length)
            ShowQuestion();
        else
            EndQuiz();
    }

    void EndQuiz()
    {
        questionText.gameObject.SetActive(false);
        foreach (var btn in choiceButtons)
            btn.gameObject.SetActive(false);

        resultPanel.SetActive(true);
        scoreText.text = "Your Score: " + score + "/" + questions.Length;

        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();
    }

    public void RestartQuiz()
    {
        if (clickSound != null) clickSound.Play(); // 🔊 play sound on restart
        UnityEngine.SceneManagement.SceneManager.LoadScene("pickleball quiz");
    }
}
