using UnityEngine;
using UnityEngine.SceneManagement;

public class SideMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del obstáculo
    public string playerTag = "Player"; // Etiqueta del jugador
    private Vector3 startPosition; // Posición inicial del objeto

    // Dirección del movimiento del obstáculo
    private int direction = 1;
    private bool hasTurnedPositive = false;
    private bool hasTurnedNegative = false;

    void Start()
    {
        // Guardar la posición inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimiento del obstáculo
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);

        // Verificar si el obstáculo ha alcanzado los límites de recorrido positivo
        if (!hasTurnedPositive && Vector3.Distance(startPosition, transform.position) >= 10f)
        {
            // Girar 180 grados
            transform.Rotate(Vector3.up, 180f);
            hasTurnedPositive = true; // Marcar que ya ha girado en el límite positivo
        }

        // Verificar si el obstáculo ha alcanzado los límites de recorrido negativo
        if (!hasTurnedNegative && Vector3.Distance(startPosition, transform.position) <= -10f)
        {
            // Girar 180 grados
            transform.Rotate(Vector3.up, 180f);
            hasTurnedNegative = true; // Marcar que ya ha girado en el límite negativo
        }

        // Si el obstáculo ha regresado a la posición inicial, reiniciar los giros
        if (Mathf.Abs(transform.position.z - startPosition.z) < 0.1f)
        {
            hasTurnedPositive = false;
            hasTurnedNegative = false;
            direction *= -1; // Invertir la dirección para moverse en la dirección opuesta
        }
    }

    // Detectar colisión con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Cargar el nivel 1
            SceneManager.LoadScene("Level2");
        }
    }
}
