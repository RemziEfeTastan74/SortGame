using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour
{
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}