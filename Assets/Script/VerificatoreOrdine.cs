using UnityEngine;

public class VerificatoreOrdine : MonoBehaviour
{
    public ManagerOrdini managerOrdini;

    private void OnTriggerStay(Collider other)
{
    ToyPiece toy = other.GetComponentInChildren<ToyPiece>();
    if (toy == null) return;

    int punti;
    bool ordineCorretto = managerOrdini.VerificaOrdine(toy, out punti);

    if (!ordineCorretto)
    {
        Debug.Log("Ordine sbagliato. Nessun punto assegnato.");
        punti = 0;
    }
    else
    {
        Debug.Log("Ordine corretto! + " + punti + " punti");
    }

    managerOrdini.CompletaOrdine(punti);
    // Se è una base, distrugge anche i pezzi
    if (toy.IsBase)
    {
        toy.DistruggiCompletamente();
    }
    else
    {
        Destroy(toy.gameObject);
    }

}
}