using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryManager : MonoBehaviour
{
    public static string selectedCategory;

    public void SelectCategory(string categoryName)
    {
        selectedCategory = categoryName;
        SceneManager.LoadScene("GameScene");
    }
}