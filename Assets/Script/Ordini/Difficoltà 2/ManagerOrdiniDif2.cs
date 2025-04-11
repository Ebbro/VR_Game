using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerOrdiniDif2 : MonoBehaviour
{
    public List<OrdineToyPiece> ordini = new List<OrdineToyPiece>();
    public TextMeshProUGUI ordineText;

    public string[] tipiPossibili = { "Orsacchiotto", "Polpo", "", ""};
    public int minQuantita = 1;
    public int maxQuantita = 2;

    [System.Serializable]
    public class OrdineToyPiece
    {   
        public string PieceType;
        public int NumberOfPieces;

        public OrdineToyPiece(string tipo, int quantita)
        {
            PieceType = tipo;
            NumberOfPieces = quantita;
        }
    }

    void Start()
    {
        GeneraNuovoOrdine();
    }

    private void GeneraNuovoOrdine()
    {
        if (tipiPossibili.Length == 0) return;

        // Seleziona tipo e quantità random
        string tipo = tipiPossibili[Random.Range(0, tipiPossibili.Length)];
        int quantita = Random.Range(minQuantita, maxQuantita + 1);

        OrdineToyPiece nuovoOrdine = new OrdineToyPiece(tipo, quantita);
        ordini.Add(nuovoOrdine);

        AggiornaTestoOrdine();
    }

    public int VerificaOrdine(ToyPiece toy)
{
    if (ordini.Count == 0 || toy == null)
        return 0;

    string tipoRichiesto = ordini[0].PieceType;
    int quantitaRichiesta = ordini[0].NumberOfPieces;

    bool contieneTipo = toy.ContieneTipoRichiesto(tipoRichiesto);
    bool quantitaCorretta = toy.NumberOfPieces == quantitaRichiesta;

    if (contieneTipo && quantitaCorretta)
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
            ordineText.text = $"Tipo: {ordine.PieceType}\nQuantità: {ordine.NumberOfPieces}";
        }
        else
        {
            ordineText.text = "Nessun ordine disponibile";
        }
    }
}
