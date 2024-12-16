using UnityEngine;
using UnityEngine.UI;

public class GamePlayerUI : MonoBehaviour
{
    public GameObject playerTextsContainer; // Le conteneur des textes des joueurs
    public Color normalColor = Color.white; // Couleur normale
    public Color highlightColor = Color.yellow; // Couleur de surbrillance

    void Start()
    {
        UpdatePlayerUI(); // Initialiser l'affichage des joueurs
    }

    public void UpdatePlayerUI()
    {
        var players = GameManager.Instance.players; // Récupère la liste des joueurs
        int currentPlayerIndex = GameManager.Instance.activePlayerIndex; // Récupère l'index du joueur actif

        for (int i = 0; i < playerTextsContainer.transform.childCount; i++)
        {
            var textObject = playerTextsContainer.transform.GetChild(i).gameObject;

            if (i < players.Count)
            {
                textObject.SetActive(true);

                // Met à jour le texte avec le nom et le score
                var playerText = textObject.GetComponent<Text>();
                playerText.text = $"{players[i].name}: {players[i].score} points";

                // Applique la couleur de surbrillance au joueur actif
                playerText.color = (i == currentPlayerIndex) ? highlightColor : normalColor;
            }
            else
            {
                textObject.SetActive(false);
            }
        }
    }
}
