using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraVida;       // Arrastra aquí el objeto "Relleno"
    public float vidaMaxima = 100f;
    private float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarBarra();
    }

    // Método para reducir vida
    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        ActualizarBarra();
    }

    // Método para actualizar visualmente la barra
    void ActualizarBarra()
    {
        if (barraVida != null)
        {
            barraVida.fillAmount = vidaActual / vidaMaxima;
        }
    }

    // Solo para probar (quita luego)
    void Update()
    {
        // Presiona la tecla "H" para recibir daño de 10 puntos
        if (Input.GetKeyDown(KeyCode.H))
        {
            RecibirDanio(10f);
        }
    }
}
