using UnityEngine;

public class VerificatoreOrdine : MonoBehaviour
{
    public ManagerOrdini managerOrdini;

    private void OnTriggerEnter(Collider other)
{
    Debug.Log($"Oggetto entrato: {other.name}");
    
}

    private void OnTriggerStay(Collider other)
    {
        ComponenteOggetto oggetto = other.GetComponent<ComponenteOggetto>();

          if (oggetto == null)
    {
        Debug.LogError($"Errore: L'oggetto {other.name} non ha il componente ComponenteOggetto!");
        return;
    }

    Debug.Log($"Tipo: {oggetto.tipo}, Quantità: {oggetto.quantita}");

        if (oggetto != null)
        {
            int punti;
            if (managerOrdini.OrdineCorrenteValido(oggetto.tipo, oggetto.quantita, out punti))
            {
                Debug.Log($"Ordine completato: {oggetto.tipo} x{oggetto.quantita}. Punti guadagnati: {punti}");
                managerOrdini.CompletaOrdine(punti);
                Destroy(other.gameObject); // Elimina l'oggetto verificato
            }
            else
            {
                Debug.Log("Oggetto non valido per l'ordine.");
            }
        }
    }
}