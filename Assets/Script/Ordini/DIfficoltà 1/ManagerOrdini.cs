using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerOrdini : MonoBehaviour
{
    public List<OrdineToyPiece> ordini = new List<OrdineToyPiece>();
    public TextMeshProUGUI ordineText;
    public AudioSource audioSource;  // Riferimento all'AudioSource
    public AudioClip ordineCorrettoClip;  // Suono per ordine corretto
    public AudioClip ordineSbagliatoClip; // Suono per ordine sbagliato


     public string[] pezziPossibili = { "Orsacchiotto", "Polpo", "", ""};
    public int minQuantita = 1;
    public int maxQuantita = 2;
    public GameManager gameManager;  // Assicurati di assegnarlo da Inspector
    public float tempoBonusPerOrdine = 15f;  // Tempo da aggiungere per ordine corretto

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
        if (gameManager != null)
        {
            gameManager.AggiungiTempo(tempoBonusPerOrdine);
        }
        return 15; // Punteggio per un ordine corretto
         audioSource.PlayOneShot(ordineSbagliatoClip);
    }

    return 0; // Nessun punteggio per un ordine sbagliato
                audioSource.PlayOneShot(ordineCorrettoClip);
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
            ordineText.text = $"Base: {ordine.PieceName}\nQuantità: {ordine.NumberOfPieces}";
        }
        else
        {
            ordineText.text = "Nessun ordine disponibile";
        }
    }
}
