using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInterface : MonoBehaviour
{
    public static GameInterface instance { get; private set;}

    bool uiVisible = false;
    [SerializeField] GameObject uiCam;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject timeOutPanel;

    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] float gameTime;
    float timeElapsed;
    bool isEnded = false;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start() {
        timeElapsed = gameTime;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            uiVisible = !uiVisible;
        }
        uiCam.SetActive(uiVisible ? true : false);

        if (timeElapsed <= 0f) {
            timer.text = "00:00";
            TimeOut();
            player.SetActive(false);
        }
        else if (!isEnded) {
            timeElapsed -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);

            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void Die() {
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        isEnded = true;
    }

    public void TimeOut() {
        timeOutPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        isEnded = true;
    }

    public void Finish() {
        finishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        isEnded = true;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}