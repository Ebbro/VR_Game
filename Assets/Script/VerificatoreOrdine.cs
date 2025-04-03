using UnityEngine;

public class VerificatoreOrdine : MonoBehaviour
{
    public ManagerOrdini managerOrdini;

    private void OnTriggerEnter(Collider other)
    {
        // Qui puoi aggiungere un controllo per verificare l'oggetto se necessario
        Debug.Log("Oggetto inserito. Verifica ordine...");

        // Completa l'ordine e genera il successivo
        managerOrdini.CompletaOrdine();
    }
}