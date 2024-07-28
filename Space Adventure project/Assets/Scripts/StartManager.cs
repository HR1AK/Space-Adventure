using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject OptionCanvas;
    [SerializeField] private GameObject StartCanvas;
    [SerializeField] private GameObject Information;
    [SerializeField] private GameObject ToMenu;


    public void StartTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void ShowOptions()
    {
        OptionCanvas.SetActive(true);
        ToMenu.SetActive(true);

        StartCanvas.SetActive(false);
        Information.SetActive(false);
    }

    public void BackToMenu()
    {
        StartCanvas.SetActive(true);

        OptionCanvas.SetActive(false);
        Information.SetActive(false);
        ToMenu.SetActive(false);
    }

    public void ShowInformation()
    {
        Information.SetActive(true);
        ToMenu.SetActive(true);

        StartCanvas.SetActive(false);
        OptionCanvas.SetActive(false);
    }
}
