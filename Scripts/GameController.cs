using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string sceneName;
    private float currentTime;
    private int currentScore;
    private int score;
    private int highScore;
    private int gameTime;
    private int spawnTime;

    [SerializeField]
    private Text txtCurrentScore;

    [SerializeField]
    private Text txtCurrentTime;

    [SerializeField]
    private Text txtHighScore;

    [SerializeField]
    private Text txtScore;

    [SerializeField]
    private Text txtTime;

    [SerializeField]
    private Text txtSpawn;


    private void Start() {
        LoadData();
        
        currentScore = 0;
        currentTime  = gameTime;

        switch (sceneName)
        {
            case "Menu":
                SetUISettings();
                break;
            
            case "Gameplay":
                SetUIGameplay();
                break;
            
            case "GameOver":
                SetUIGameOver();
                break;
        }
    }

    private void Update() {
        if(sceneName == "Gameplay")
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SaveData();
                LoadNextScene("GameOver");
            }
            SetUIGameplay();
        }
    }

    
    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("GameTime", gameTime);
        PlayerPrefs.SetInt("SpawnTime", spawnTime);
    }

    private void LoadData()
    {
        score     = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore");
        gameTime  = PlayerPrefs.GetInt("GameTime");
        spawnTime = PlayerPrefs.GetInt("SpawnTime");
    }

    public void ToScore()
    {
        currentScore++;
        if(currentScore > score) score = currentScore;
        if(currentScore > highScore) highScore = currentScore;

        SetUIGameplay();
    }

    public void SetGameTime(int time)
    {
        gameTime += time;
        gameTime = gameTime < 60 ? 60 :
                    gameTime > 180 ? 180 : gameTime;

        SetUISettings();
        
    }

    public void SetSpawnTime(int time)
    {
        spawnTime += time;
        spawnTime = spawnTime < 1 ? 1 : spawnTime;

        SetUISettings();
        
    }

    public void SetUIGameplay()
    {
        txtCurrentScore.text = "Score: " + currentScore.ToString() + "pts";
        txtCurrentTime.text  = "Time: "  + ((int)currentTime).ToString()     + "s";
    }

    public void SetUIGameOver()
    {
        txtScore.text     = "Score: " + score.ToString() + "pts";
        txtHighScore.text = "High Score: " + highScore.ToString() + "pts";
    }

    public void SetUISettings()
    {
        txtTime.text  = gameTime.ToString()  + "s";
        txtSpawn.text = spawnTime.ToString() + "s";
    }

    public void LoadNextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

}
