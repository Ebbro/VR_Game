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
    public GameManager gameManager;  // Assicurati di assegnarlo da Inspector
    public float tempoBonusPerOrdine = 30f;  // Tempo da aggiungere per ordine corretto

    [System.Serializable]
    public class OrdineToyPiece
    {   
        public string PieceTarget;
        public int NumberOfPieces;
        public string PieceName;

        public OrdineToyPiece(string basePezzo, string pezzoSpecifico, int quantita)
        {
            PieceName = basePezzo;
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

        OrdineToyPiece nuovoOrdine = new OrdineToyPiece(basePezzo, pezzoSpecifico, quantita);
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
        if (gameManager != null)
        {
            gameManager.AggiungiTempo(tempoBonusPerOrdine);
        }
        return 45; // Punteggio per un ordine corretto
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
            ordineText.text = $"{ordine.PieceName}\n+ {ordine.PieceTarget}\n+ {ordine.NumberOfPieces - 1} Pezzi";
        }
        else
        {
            ordineText.text = "Nessun ordine disponibile";
        }
    }
}
