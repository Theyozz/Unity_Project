using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Text[] playerTexts; // Tableau des textes des joueurs
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

        public void RemovePlayer()
    {
        if (currentPlayerCount > 1)
        {
            playerTexts[currentPlayerCount - 1].gameObject.SetActive(false);
            currentPlayerCount--;
        }
    }

    // Méthode appelée par le bouton "Commencer"
    public void StartGame()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance est null. Assurez-vous que le GameManager est présent dans la scène.");
            return;
        }

        GameManager.Instance.InitializePlayers(currentPlayerCount); // Initialisation des joueurs dans le GameManager
        Debug.Log("Partie commencée avec " + currentPlayerCount + " joueurs !");
        SceneManager.LoadScene("Game"); // Charger la scène "Game"
    }

    private void AssignPointsToActivePlayer(int points)
    {
        var currentPlayer = GameManager.Instance.GetCurrentPlayer();
        if (currentPlayer != null)
        {
            currentPlayer.score += points;
            Debug.Log($"{currentPlayer.name} a marqué {points} points ! Score total : {currentPlayer.score}");
            
            // Vérifie si ce joueur a gagné
            GameManager.Instance.CheckForWinner();
        }
        else
        {
            Debug.LogError("Aucun joueur actif trouvé !");
        }
    }

}
