using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Vitesse de déplacement
    public float minX = -9.5f; // Limite gauche
    public float maxX = 9f; // Limite droite

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Désactiver la gravité au départ
    }

    void Update()
    {
        // Déplacement horizontal
        float moveX = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(moveX, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;

        // Activer la gravité lorsque la barre d'espace est enfoncée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
        }
    }
}
