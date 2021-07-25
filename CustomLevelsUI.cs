using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomLevelsUI : MonoBehaviour
{
    public InputField m_newLevelNameControl;

    public void StartNewLevel()
    {
        LevelCreator.m_levelName = m_newLevelNameControl.text;
        SceneManager.LoadScene("LevelCreator");
    }
}
