using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerOrdini : MonoBehaviour
{
    public List<OrdineToyPiece> ordini = new List<OrdineToyPiece>();
    public TextMeshProUGUI ordineText;


     public string[] pezziPossibili = { "Orsacchiotto", "Polpo", "", ""};
    public int minQuantita = 1;
    public int maxQuantita = 2;

    [System.Serializable]
    public class OrdineToyPiece
    {   
        public int NumberOfPieces;
        public string PieceName;

        public OrdineToyPiece(string pezzo, int quantita)
        {
            PieceName = pezzo;
            NumberOfPieces = quantita;
        }
    }

    void Start()
    {
        GeneraNuovoOrdine();
    }

    private void GeneraNuovoOrdine()
    {
        if (pezziPossibili.Length == 0) return;

        // Seleziona tipo e quantità random
        string pezzo = pezziPossibili[Random.Range(0, pezziPossibili.Length)];
        int quantita = Random.Range(minQuantita, maxQuantita + 1);

        OrdineToyPiece nuovoOrdine = new OrdineToyPiece(pezzo, quantita);
        ordini.Add(nuovoOrdine);

        AggiornaTestoOrdine();
    }

    public int VerificaOrdine(ToyPiece toy)
{
    if (ordini.Count == 0 || toy == null)
        return 0;

    string pezzoRichiesto = ordini[0].PieceName;
    int quantitaRichiesta = ordini[0].NumberOfPieces;

    bool contienePezzo = toy.ContienePezzoRichiesto(pezzoRichiesto);
    bool quantitaCorretta = toy.NumberOfPieces == quantitaRichiesta;

    if (quantitaCorretta && contienePezzo)
    {
        return 15; // Punteggio per un ordine corretto
    }

    return 0; // Nessun punteggio per un ordine sbagliato
}

    public void CompletaOrdine()
{
    if (ordini.Count > 0)
    {
        ordini.RemoveAt(0);
        if (ordini.Count == 0)
        {
            GeneraNuovoOrdine();
        }
        AggiornaTestoOrdine();
    }
}
    private void AggiornaTestoOrdine()
    {
        if (ordini.Count > 0)
        {
            var ordine = ordini[0];
            ordineText.text = $"Pezzo: {ordine.PieceName}\nQuantità: {ordine.NumberOfPieces}";
        }
        else
        {
            ordineText.text = "Nessun ordine disponibile";
        }
    }
}
