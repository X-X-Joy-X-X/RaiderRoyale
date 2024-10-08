using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeMenuScene()
    {
        SceneManager.LoadScene("Scenes/Menu Scenes/MainMenu");
    }
}
