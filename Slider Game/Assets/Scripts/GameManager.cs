using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ObstacleMover[] obstacles;
    public GameObject restartMenu;
    public bool paused;
    public Score score;

    public void EndGame()
    {
        obstacles = FindObjectsOfType<ObstacleMover>();
        foreach(ObstacleMover obstacle in obstacles)
        {
            obstacle.enabled = false;
        }

        score.RecordHighScore();

        FindObjectOfType<TimeManager>().slowMotion();
        FindObjectOfType<Spawner>().enabled = false;
        FindObjectOfType<Score>().enabled = false;
        FindObjectOfType<PlayerCollision>().enabled = false;
        FindObjectOfType<PlayerMovement>().enabled = false;

        Invoke("ShowRestartMenu", FindObjectOfType<TimeManager>().slowdownLength / 2);
    }

    private void ShowRestartMenu()
    {
        restartMenu.SetActive(true);
        paused = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
