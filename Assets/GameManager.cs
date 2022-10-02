using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool GameHasEnded = false;
    public float RestartDelay = 2f;

    public void EndGame()
    {
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            FindObjectOfType<Score>().GameHasEnded = true;
            Invoke("Restart", RestartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
