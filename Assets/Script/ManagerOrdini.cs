using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerOrdini : MonoBehaviour
{
    

   public List<OrdineToyPiece> ordini = new List<OrdineToyPiece>();
    public TextMeshProUGUI ordineText;
    public Text punteggioText; // Testo per visualizzare il punteggio

    public string[] tipiPossibili = { "Orsacchiotto", "Polpo", "", ""};
    public int minQuantita = 1;
    public int maxQuantita = 2;

    private int punteggio = 0; // Punteggio totale del giocatore
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
        AggiornaTestoPunteggio();
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

public bool VerificaOrdine(ToyPiece toy, out int punti)
{
    punti = 0;

    if (ordini.Count == 0 || toy == null)
        return false;

    string tipoRichiesto = ordini[0].PieceType;
    int quantitaRichiesta = ordini[0].NumberOfPieces;

    bool contieneTipo = toy.ContieneTipoRichiesto(tipoRichiesto);
    bool quantitaCorretta = toy.NumberOfPieces == quantitaRichiesta;

    if (contieneTipo && quantitaCorretta)
    {
        punti = 15;
        return true;
    }

    return false;
}

    public void CompletaOrdine(int punti)
    {
        if (ordini.Count > 0)
        {
            ordini.RemoveAt(0);
            punteggio += punti; // Aggiunge il punteggio ottenuto
            AggiornaTestoPunteggio();

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

    private void AggiornaTestoPunteggio()
    {
        punteggioText.text = $"Punteggio: {punteggio}";
    }
}