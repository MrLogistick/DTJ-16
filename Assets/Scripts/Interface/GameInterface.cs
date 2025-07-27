using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInterface : MonoBehaviour
{
    public static GameInterface instance { get; private set;}

    [SerializeField] GameObject gameOverPanel;

    public void Die() {
        gameOverPanel.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}