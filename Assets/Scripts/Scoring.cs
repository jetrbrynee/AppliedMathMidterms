using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    

    void Start()
    {
        // Para ma reset yung score sa 0 everytime irerestart yung game
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Score") + "";
    }
}
