using UnityEngine;

public class prueba : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del obstáculo
    public GameObject gameOverUI; // Canvas que contiene el menú de Game Over
    private bool isDead; // Para saber si murió y activar el menú
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
        
        // Desactivar el canvas de Game Over al inicio
        gameOverUI.SetActive(false);
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
        if (other.CompareTag(playerTag) && !isDead)
        {
            // Marcar que el jugador está muerto
            isDead = true;

            // Activar el canvas de Game Over
            gameOverUI.SetActive(true);
            
            // Pausar el juego
            Time.timeScale = 0f;
        }
    }
}
