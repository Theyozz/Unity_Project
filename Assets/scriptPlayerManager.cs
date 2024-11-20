using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Nécessaire pour charger des scènes

public class PlayerManager : MonoBehaviour
{
    public Text[] playerTexts; // Array des textes des joueurs
    private int currentPlayerCount = 1; // Nombre actuel de joueurs (Joueur 1 est toujours visible)

    // Méthode appelée par le bouton "Add Player"
    public void AddPlayer()
    {
        if (currentPlayerCount < playerTexts.Length)
        {
            currentPlayerCount++;
            playerTexts[currentPlayerCount - 1].gameObject.SetActive(true);
        }
    }

    // Méthode appelée par le bouton "Commencer"
    public void StartGame()
    {
        Debug.Log("Partie commencée avec " + currentPlayerCount + " joueurs !");
        // Charger la scène nommée "Game"
        SceneManager.LoadScene("Game");
    }
}
