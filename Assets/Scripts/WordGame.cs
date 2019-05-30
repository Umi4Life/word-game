using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WordGame : MonoBehaviour
{
    [SerializeField] Text question;
    [SerializeField] InputField answer;
    SceneLoader sceneLoader;
    Score score;
    [SerializeField] Text timer;
    float timeLeft = 7.0f;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        score = FindObjectOfType<Score>();
        List<string> words = score.words;
        NextWord(words[UnityEngine.Random.Range(0, words.Count)]);
    }

    void NextWord(string lastWord)
    {
        timeLeft = 7.0f;
        answer.text = "";
        List<String> filtered = score.words.Where(w => w[0] == lastWord[lastWord.Length - 1]).ToList();
        question.text = filtered[UnityEngine.Random.Range(0,filtered.Count)];
        score.UpdateScore(question.text);

    }

    public void OnSubmit()
    {
        char answer_first = answer.text[0];
        char answer_last = answer.text[answer.text.Length - 1];

        char question_first = question.text[0];
        char question_last = question.text[question.text.Length - 1];

        if(
            answer_first == question_last &&
            score.words.Contains(answer.text.ToLower()) && 
            !score.used_words.Contains(answer.text.ToLower())
            )
        {
            score.UpdateScore(answer.text);
            NextWord(answer.text);
        }

    }

    // Update is called once per frame

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "Time Left: " + timeLeft.ToString("0.0");
        if (timeLeft <= 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
