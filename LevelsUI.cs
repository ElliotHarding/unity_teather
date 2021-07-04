using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsUI : MonoBehaviour
{
    public GameObject m_levelButtonPrefab;

    public GameObject m_levelsPanel;
    public int m_numLevels;

    private int m_completedLevels;
    private List<GameObject> m_buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        m_completedLevels = PlayerPrefs.GetInt("CompletedLevels", 0);

        for (int i = 0; i < m_numLevels; i++)
        {
            int level = i + 1;
            GameObject button = (GameObject)Instantiate(m_levelButtonPrefab);
            button.transform.SetParent(m_levelsPanel.transform);
            button.GetComponent<Button>().onClick.AddListener(() => LevelButtonClicked(level));
            button.GetComponentInChildren<Text>().text = level.ToString();

            button.GetComponent<Image>().color = (level <= m_completedLevels + 1) ? Color.green : Color.red;

            m_buttons.Add(button);
        }
    }

    void LevelButtonClicked(int level)
    {
        if(level <= m_completedLevels + 1)
        {
            Debug.Log("Loading Level " + level.ToString());
            SceneManager.LoadScene("Level" + level.ToString());
        }        
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("CompletedLevels", 0);

        foreach(GameObject button in m_buttons)
        {
            Destroy(button);
        }
        m_buttons.Clear();

        Start();
    }

}
