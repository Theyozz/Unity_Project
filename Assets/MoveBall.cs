using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Vitesse de déplacement
    public float minX = -9.5f; // Limite gauche
    public float maxX = 9f; // Limite droite
    public Vector3 initialPosition = new Vector3(0, 1, 0); // Position initiale de la balle

    private Rigidbody rb;
    private bool canMove = true; // Contrôle si le joueur peut se déplacer

    private GameManager gameManager; // Référence au GameManager

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        // Référence au GameManager
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager n'est pas trouvé. Assurez-vous qu'il est dans la scène.");
        }

        // Positionner la balle au début
        ResetBall();
    }

    void Update()
    {
        if (canMove)
        {
            // Mouvement horizontal du joueur
            float moveX = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(moveX, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }

        // Lancer la balle avec la barre d'espace
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            canMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Gérer les collisions avec les cibles
        int points = 0;

        switch (collision.gameObject.tag)
        {
            case "50":
                points = 50;
                break;
            case "100":
                points = 100;
                break;
            case "150":
                points = 150;
                break;
            case "200":
                points = 200;
                break;
            case "300":
                points = 300;
                break;
        }

        if (points > 0)
        {
            AssignPointsToActivePlayer(points);
            FreezeBall();
            ProceedToNextPlayer();
        }
    }

    private void AssignPointsToActivePlayer(int points)
    {
        // Récupérer le joueur actif et lui ajouter des points
        var currentPlayer = gameManager.GetCurrentPlayer();
        if (currentPlayer != null)
        {
            currentPlayer.score += points;
            Debug.Log($"{currentPlayer.name} a marqué {points} points ! Score total : {currentPlayer.score}");
        }
        else
        {
            Debug.LogError("Aucun joueur actif trouvé !");
        }
    }

    private void FreezeBall()
    {
        // Stopper la balle
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    private void ProceedToNextPlayer()
    {
        // Passer au joueur suivant
        gameManager.NextPlayer(); 

        // Réinitialiser la balle et autoriser le mouvement
        ResetBall();

        // Mettre à jour l'UI (surligner le joueur actif)
        FindObjectOfType<GamePlayerUI>().UpdatePlayerUI();
    }

    private void ResetBall()
    {
        // Réinitialiser la position et les propriétés physiques de la balle
        transform.position = initialPosition;
        rb.isKinematic = false;
        rb.useGravity = false;
        canMove = true;
    }
}
