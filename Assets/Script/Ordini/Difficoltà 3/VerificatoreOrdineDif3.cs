using UnityEngine;

public class VerificatoreOrdineDif3 : MonoBehaviour
{
    public ManagerOrdiniDif3 ManagerOrdiniDif3;

    private void OnTriggerStay(Collider other)
    {
        ToyPiece toy = other.GetComponentInParent<ToyPiece>();
        if (toy == null) return;

        int punti = ManagerOrdiniDif3.VerificaOrdine(toy);  // Ora otteniamo il punteggio direttamente

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
        ManagerOrdiniDif3.CompletaOrdine();

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
