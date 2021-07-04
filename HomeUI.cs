using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    public void StartButton()//cant call it start
    {
        SceneManager.LoadScene("Levels");
    }
}
