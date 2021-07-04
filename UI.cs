using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    public Sprite m_pauseSprite;
    public Sprite m_playSprite;
    public Image m_pauseButtonImage;
    private bool m_bPaused = false;
    public void Pause()
    {
        m_bPaused = !m_bPaused;
        if (m_bPaused)
        {
            Time.timeScale = 0;
            m_pauseButtonImage.sprite = m_playSprite;
        }
        else
        {
            Time.timeScale = 1;
            m_pauseButtonImage.sprite = m_pauseSprite;
        }
    }

    public void NextLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
