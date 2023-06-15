using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObject;
    // Start is called before the first frame update

    private void Start()
    {
        gameObject = GameObject.FindWithTag("GameOver");
        gameObject.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameObject.SetActive(true);
    }
}
