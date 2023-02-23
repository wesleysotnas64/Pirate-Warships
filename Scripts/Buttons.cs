using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void Settings()
    {
        GameObject.Find("Main Camera").GetComponent<MenuCamera>().SetSettingsAsTarget();
    }

    public void Menu()
    {
        GameObject.Find("Main Camera").GetComponent<MenuCamera>().SetMenuAsTarget();
        GameObject.Find("GameController").GetComponent<GameController>().SaveData();
    }

    public void GameTimeUp()
    {
        GameObject.Find("GameController").GetComponent<GameController>().SetGameTime(5);
    }

    public void GameTimeDown()
    {
        GameObject.Find("GameController").GetComponent<GameController>().SetGameTime(-5);
    }

    public void SpawnTimeUp()
    {
        GameObject.Find("GameController").GetComponent<GameController>().SetSpawnTime(1);
    }

    public void SpawnTimeDown()
    {
        GameObject.Find("GameController").GetComponent<GameController>().SetSpawnTime(-1);
    }

    public void LoadNextScene(string scene)
    {
        GameObject.Find("GameController").GetComponent<GameController>().LoadNextScene(scene);
    }
}
