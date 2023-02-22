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
    }
}
