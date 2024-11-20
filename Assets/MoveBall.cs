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
        rb.useGravity = false;
    }

    void Update()
    {
        if (canMove)
        {
            float moveX = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(moveX, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            canMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "50":
                score += 50;
                Debug.Log("Score: " + score);
                FreezeBall();
                break;
            case "100":
                score += 100;
                Debug.Log("Score: " + score);
                FreezeBall();
                break;
            case "150":
                score += 150;
                Debug.Log("Score: " + score);
                FreezeBall();
                break;
            case "200":
                score += 200;
                Debug.Log("Score: " + score);
                FreezeBall();
                break;
            case "300":
                score += 300;
                Debug.Log("Score: " + score);
                FreezeBall();
                break;
        }
    }
    private void FreezeBall()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
