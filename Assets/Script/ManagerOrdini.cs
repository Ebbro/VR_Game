using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerOrdini : MonoBehaviour
{
    [System.Serializable]
    public class ComponenteOrdine
    {
        public string tipo;
        public int quantita;

        public ComponenteOrdine(string tipo, int quantita)
        {
            this.tipo = tipo;
            this.quantita = quantita;
        }
    }

    public List<ComponenteOrdine> ordini = new List<ComponenteOrdine>();
    public TextMeshProUGUI ordineText;
    public Text punteggioText; // Testo per visualizzare il punteggio

    public string[] tipiPossibili = { "Orsacchiotto", "Polpo", "", ""};
    public int minQuantita = 1;
    public int maxQuantita = 2;

    private int punteggio = 0; // Punteggio totale del giocatore

    void Start()
    {
        GeneraNuovoOrdine();
        AggiornaTestoPunteggio();
    }

    private void GeneraNuovoOrdine()
    {
        string tipo = tipiPossibili[Random.Range(0, tipiPossibili.Length)];
        int quantita = Random.Range(minQuantita, maxQuantita + 1);

        ordini.Add(new ComponenteOrdine(tipo, quantita));
        AggiornaTestoOrdine();
    }

public bool VerificaOrdine(ToyPiece toyPiece, out int punti)
{
    punti = 0;

    if (ordini.Count == 0 || toyPiece == null)
        return false;

    string tipoPezzo = toyPiece.GetPieceType();
    int numeroPezzi = toyPiece.GetNumberOfPieces();

    bool tipoCorretto = ordini[0].tipo == tipoPezzo;
    bool quantitaCorretta = ordini[0].quantita == numeroPezzi;

    if (tipoCorretto && quantitaCorretta)
    {
        punti = 15; // o usa valori serializzati
        if (GameManager.Instance != null)
            GameManager.Instance.AggiungiTempo(15f);

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
            ordineText.text = $"Tipo: {ordini[0].tipo}\nQuantità: {ordini[0].quantita}";
        else
            ordineText.text = "Nessun ordine disponibile";
    }

    private void AggiornaTestoPunteggio()
    {
        punteggioText.text = $"Punteggio: {punteggio}";
    }
}