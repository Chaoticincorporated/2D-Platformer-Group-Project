using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
