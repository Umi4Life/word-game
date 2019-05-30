using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public List<string> words = new List<string>(File.ReadAllLines("Assets/Scripts/filtered_words.txt"));
    public List<string> used_words = new List<string>();
    [SerializeField] Text scoreText;
    readonly string DICTIONARY_PATH = "Assets/Scripts/filtered_words.txt";

    public void UpdateScore(string word)
    {
        scoreText.text = scoreText.text + word + ", ";
        used_words.Add(word);
        words.Remove(word);
    }
}
