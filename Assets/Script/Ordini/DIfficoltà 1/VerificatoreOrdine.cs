using UnityEngine;

public class VerificatoreOrdine : MonoBehaviour
{
    public ManagerOrdini managerOrdini;


    private void OnTriggerEnter(Collider other)
    {
        ToyPiece toy = other.GetComponent<ToyPiece>();
        if (toy == null) return;
        // Controlla se il pezzo è una "base"
        if (!toy.IsBase)
        {
            // Se non è una base, non verificare l'ordine e uscire dalla funzione
            return;
        }


        int punti = managerOrdini.VerificaOrdine(toy);  // Ora otteniamo il punteggio direttamente

        if (punti == 0)
        {
            Debug.Log("Ordine sbagliato. Nessun punto assegnato.");
           
        }
        else
        {
            Debug.Log("Ordine corretto! + " + punti + " punti");
 
        }

        // Passa i punti al GameManager per la gestione del punteggio
        GameManager.Instance.AggiungiPunti(punti);

        // Completa l'ordine nel ManagerOrdini (senza passare il punteggio qui)
        managerOrdini.CompletaOrdine();

        // Se è una base, distrugge completamente il giocattolo
        if (toy.IsBase)
        {
            toy.DistruggiCompletamente();
        }
        else
        {
            // Distruggi solo il gioco, se non è una base
            if (toy != null)
            {
                Destroy(toy.gameObject);
            }
        }
    }

}
