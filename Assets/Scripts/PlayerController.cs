using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidad del movimiento
    public float speed = 5f;

    // Variables para guardar el input
    private float horizontal;
    private float vertical;

    // Referencia al Rigidbody
    private Rigidbody rb;

    void Start()
    {
        // Obtenemos el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Guardamos los valores de los ejes al inicio de cada frame
        horizontal = Input.GetAxis("Horizontal"); // A/D
        vertical = Input.GetAxis("Vertical");     // W/S
    }

    void FixedUpdate()
    {
        // Creamos el vector de movimiento
        Vector3 move = new Vector3(horizontal, 0f, vertical);

        // Normalizamos el vector para que en diagonal no vaya más rápido
        if (move.magnitude > 1f)
            move.Normalize();

        // Movemos al jugador multiplicando por la velocidad
        rb.MovePosition(transform.position + move * speed * Time.fixedDeltaTime);
    }
}
