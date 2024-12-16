using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Ajoutez ceci pour accéder à SceneManager


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Player> players = new List<Player>(); // Liste des joueurs
    public int activePlayerIndex = 0; // Index du joueur actif
    public string winnerMessage = ""; // Message pour le gagnant

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Player GetCurrentPlayer()
    {
        return players[activePlayerIndex];
    }

    public void NextPlayer()
    {
        activePlayerIndex = (activePlayerIndex + 1) % players.Count;
    }

    public void InitializePlayers(int playerCount)
    {
        players.Clear();
        for (int i = 0; i < playerCount; i++)
        {
            players.Add(new Player { name = $"Player {i + 1}", score = 0 });
        }
    }

    public void CheckForWinner()
    {
        foreach (var player in players)
        {
            if (player.score >= 300)
            {
                winnerMessage = $"{player.name} a gagné la partie avec un total de {player.score} points !";
                EndGame();
                break;
            }
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Menu"); // Charger la scène GameOver
    }
}
