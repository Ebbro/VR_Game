using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerOrdiniDif3 : MonoBehaviour
{
    public List<OrdineToyPiece> ordini = new List<OrdineToyPiece>();
    public TextMeshProUGUI ordineText;

    public string[] pezziSpecifici = { "Orsacchiotto", "Polpo", "", ""};
    public string[] basi = { "Orsacchiotto", "Polpo", "", ""};
    public int minQuantita = 1;
    public int maxQuantita = 2;

    [System.Serializable]
    public class OrdineToyPiece
    {   
        public string PieceTarget;
        public int NumberOfPieces;
        public string PieceName;

        public OrdineToyPiece(string pezzoSpecifico, int quantita)
        {
            PieceTarget = pezzoSpecifico;
            NumberOfPieces = quantita;
        }
    }

    void Start()
    {
        GeneraNuovoOrdine();
    }

    private void GeneraNuovoOrdine()
    {
        if (pezziSpecifici.Length == 0) return;

        // Seleziona tipo e quantità random
         string basePezzo = basi[Random.Range(0, basi.Length)];
        string pezzoSpecifico = pezziSpecifici[Random.Range(0, pezziSpecifici.Length)];
        int quantita = Random.Range(minQuantita, maxQuantita + 1);

        OrdineToyPiece nuovoOrdine = new OrdineToyPiece(pezzoSpecifico, quantita);
        ordini.Add(nuovoOrdine);

        AggiornaTestoOrdine();
    }

    public int VerificaOrdine(ToyPiece toy)
{
    if (ordini.Count == 0 || toy == null)
        return 0;

    string pezzoSpecificoRichiesto = ordini[0].PieceTarget;
    string pezzoRichiesto = ordini[0].PieceName;
    int quantitaRichiesta = ordini[0].NumberOfPieces;

    bool contienePezzoSpecifico = toy.ContienePezzoRichiesto(pezzoSpecificoRichiesto);
    bool contienePezzo = toy.ContienePezzoRichiesto(pezzoRichiesto);
    bool quantitaCorretta = toy.NumberOfPieces == quantitaRichiesta;

    if (contienePezzoSpecifico && quantitaCorretta && contienePezzo)
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
            ordineText.text = $"Base:{ordine.PieceName}\nPezzo: {ordine.PieceTarget}\nQuantità: {ordine.NumberOfPieces}";
        }
        else
        {
            ordineText.text = "Nessun ordine disponibile";
        }
    }
}
