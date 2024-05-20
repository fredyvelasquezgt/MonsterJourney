using UnityEngine;
using UnityEngine.SceneManagement;

public class sinMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del obstáculo
    public float frequency = 2f; // Frecuencia del movimiento sinusoidal
    public float amplitude = 1f; // Amplitud del movimiento sinusoidal
    public string playerTag = "Player"; // Etiqueta del jugador
    private Vector3 startPosition; // Posición inicial del objeto
    private Rigidbody rb; // Componente Rigidbody del personaje

    void Start()
    {
        // Guardar la posición inicial del objeto
        startPosition = transform.position;
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento sinusoidal del obstáculo
        float yPos = Mathf.Sin(Time.time * frequency) * amplitude; // Ajusta la frecuencia y la amplitud del movimiento
        transform.position = startPosition + new Vector3(0f, yPos, 0f);

        // Rotación suave mientras se mueve
        transform.Rotate(Vector3.up, Time.deltaTime * 30f);

        // Movimiento lineal en la dirección del jugador
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Detectar colisión con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Aplicar fuerza aleatoria al personaje
            Vector3 randomForce = new Vector3(Random.Range(-10f, 10f), Random.Range(5f, 15f), Random.Range(-10f, 10f));
            rb.AddForce(randomForce, ForceMode.Impulse);

            // Cargar el nivel 1 después de un breve retraso para mostrar el efecto de la fuerza
            Invoke("LoadLevel", 1f);
        }
    }

    // Método para cargar el nivel
    private void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
