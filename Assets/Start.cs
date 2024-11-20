using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Méthode appelée par le bouton Jouer
    public void StartGame()
    {
        // Charge la scène "Game"
        SceneManager.LoadScene("Players");
    }

    // Méthode pour quitter le jeu (facultatif)
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");
        Application.Quit();
    }
}
