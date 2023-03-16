using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public int currentLevelId;
    [SerializeField] Button continueButton;

    private void Start()
    {
        currentLevelId = PlayerPrefs.GetInt("currentLevel");

        continueButton.interactable = currentLevelId != 0;
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(currentLevelId);
    }
}
