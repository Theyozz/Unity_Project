using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GamePlayerUI gamePlayerUI; // Référence au script UI pour mettre à jour l'affichage

    public void BallLaunched(int pointsScored)
    {
        // Récupérer le joueur actif
        Player currentPlayer = GameManager.Instance.GetCurrentPlayer();

        // Ajouter le score au joueur actif
        currentPlayer.score += pointsScored;
        Debug.Log($"{currentPlayer.name} a marqué {pointsScored} points ! Score total : {currentPlayer.score}");

        // Passer au joueur suivant
        GameManager.Instance.NextPlayer();

        // Mettre à jour l'affichage des joueurs
        gamePlayerUI.UpdatePlayerUI();
    }
}
