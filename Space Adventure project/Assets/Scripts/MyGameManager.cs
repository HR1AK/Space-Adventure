using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    //GameObjects
    public static MyGameManager instance;


    //Canvases
    [SerializeField] private GameObject volumeUI;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject StopScreen;
    [SerializeField] private GameObject ContinueScreen;
    [SerializeField] private GameObject ShootScreen;
    [SerializeField] private GameObject PlayerControllScreen;
    [SerializeField] private GameObject IceDebuffCanvas;

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
        InstantiateGameObjects();
        
    }

    public void InstantiateGameObjects()
    {
        //Instantiate(player);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        ContinueScreen.SetActive(false);
        StopScreen.SetActive(false);
        ShootScreen.SetActive(false);
        volumeUI.SetActive(true);
        PlayerControllScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StopGame()
    {
        StopScreen.SetActive(false);
        ContinueScreen.SetActive(true);
        ShootScreen.SetActive(false);
        volumeUI.SetActive(true);
        PlayerControllScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        ContinueScreen.SetActive(false);
        StopScreen.SetActive(true);
        ShootScreen.SetActive(true);
        volumeUI.SetActive(false);
        PlayerControllScreen.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ShowDebuffCanvas()
    {
        IceDebuffCanvas.SetActive(true);
    }

    public void HideDebuffCanvas()
    {
        if(IceDebuffCanvas)
            IceDebuffCanvas.SetActive(false);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
