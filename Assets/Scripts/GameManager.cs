using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver, startGame;
    public GameObject quitButton;
    public GameObject BackgroundAudio;
    public GameObject endMusic;

    private int score;

    private void Start()
    {
        startGame.SetActive(true);
        gameOver.SetActive(false);
        endMusic.SetActive(false);
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play()
    {
        SoundManager.PlaySound("click");
        score = 0;
        scoreText.text = score.ToString();

        BackgroundAudio.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        gameOver.SetActive(false);
        startGame.SetActive(false);
        endMusic.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; //pysäytetään peli!
        player.enabled = false;
    }

    public void GameOver() //laitetaan napit aktiiviseksi
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        SoundManager.PlaySound("gameover");
        endMusic.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        SoundManager.PlaySound("score"); //toistetaan ääni
    }
    public void Exit()
    {
        Application.Quit();
        SoundManager.PlaySound("click");
    }
}
