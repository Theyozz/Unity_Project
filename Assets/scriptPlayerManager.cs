using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // N�cessaire pour charger des sc�nes

public class PlayerManager : MonoBehaviour
{
    public Text[] playerTexts; // Array des textes des joueurs
    private int currentPlayerCount = 1; // Nombre actuel de joueurs (Joueur 1 est toujours visible)

    // M�thode appel�e par le bouton "Add Player"
    public void AddPlayer()
    {
        if (currentPlayerCount < playerTexts.Length)
        {
            currentPlayerCount++;
            playerTexts[currentPlayerCount - 1].gameObject.SetActive(true);
        }
    }

    // M�thode appel�e par le bouton "Commencer"
    public void StartGame()
    {
        Debug.Log("Partie commenc�e avec " + currentPlayerCount + " joueurs !");
        // Charger la sc�ne nomm�e "Game"
        SceneManager.LoadScene("Game");
    }
}
