using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField pass;

    // Start is called before the first frame update
   public void GoToMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
