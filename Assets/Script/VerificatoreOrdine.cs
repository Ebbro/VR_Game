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
    ComponenteOggetto oggetto = other.GetComponentInChildren<ComponenteOggetto>();

    if (oggetto == null)
    {
        Debug.LogError($"Errore: L'oggetto {other.name} non ha il componente ComponenteOggetto!");
        return;
    }

    Debug.Log($"Tipo: {oggetto.tipo}, Quantità: {oggetto.quantita}");

    int punti;
    // Ora il metodo restituisce sempre true
    managerOrdini.OrdineCorrenteValido(oggetto.tipo, oggetto.quantita, out punti);
    managerOrdini.CompletaOrdine(punti);
    Destroy(other.gameObject);
}
}