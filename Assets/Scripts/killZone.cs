using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class killZone : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TMPro.TextMeshProUGUI m_TextMeshPro;
    [SerializeField] Button reloadBtn;
    [SerializeField] Button quitBtn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        m_TextMeshPro.fontSize = 36;
        reloadBtn.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        quitBtn.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        reloadBtn.onClick.AddListener(TaskOnClick);
        quitBtn.onClick.AddListener(Quit);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("Jeu_Complet");
        Time.timeScale = 1;
    }

    void Quit ()
    {
        Application.Quit();
    

    }
}
