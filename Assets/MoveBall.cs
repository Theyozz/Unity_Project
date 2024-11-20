using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Vitesse de déplacement
    public float minX = -9.5f; // Limite gauche
    public float maxX = 9f; // Limite droite

    private Rigidbody rb;
    private bool canMove = true; // Contrôle si le joueur peut se déplacer
    private int score = 0; // Compteur de points

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Désactiver la gravité au départ
    }

    void Update()
    {
        // Déplacement horizontal, seulement si le joueur peut bouger
        if (canMove)
        {
            float moveX = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(moveX, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }

        // Activer la gravité et désactiver le déplacement lorsque la barre d'espace est enfoncée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            canMove = false; // Désactiver le déplacement horizontal
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("50"))
        {
            score += 50;
            Debug.Log("Score: " + score);
            FreezeBall(); // Appeler la fonction pour figer la balle
        } 
        else if (collision.gameObject.CompareTag("100")) 
        {
            score += 100;
            Debug.Log("Score: " + score);
            FreezeBall();
        } 
        else if (collision.gameObject.CompareTag("150")) 
        {
            score += 150;
            Debug.Log("Score: " + score);
            FreezeBall();
        } 
        else if (collision.gameObject.CompareTag("200")) 
        {
            score += 200;
            Debug.Log("Score: " + score);
            FreezeBall();
        } 
        else if (collision.gameObject.CompareTag("300")) 
        {
            score += 300;
            Debug.Log("Score: " + score);
            FreezeBall();
        }
    }

    // Fonction pour figer la balle
    private void FreezeBall()
    {
        rb.linearVelocity = Vector3.zero; // Stopper tout mouvement
        rb.angularVelocity = Vector3.zero; // Stopper la rotation
        rb.isKinematic = true; // Désactiver les forces physiques sur la balle
    }
}
