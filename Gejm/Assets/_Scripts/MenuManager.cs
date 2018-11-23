using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject[] images;

    public void Exit()
    {
        Application.Quit();
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
