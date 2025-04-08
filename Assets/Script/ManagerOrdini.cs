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

    public bool OrdineCorrenteValido(string tipo, int quantita, out int punti)
    {
        punti = 0;

        if (ordini.Count > 0)
        {
            float tempoBonus = 0;
            bool tipoCorretto = ordini[0].tipo == tipo;
            bool quantitaCorretta = ordini[0].quantita == quantita;

            if (tipoCorretto) punti += 10;  // 10 punti per il tipo giusto
            if (tipoCorretto) tempoBonus += 10; // ad esempio 10 secondi
            if (quantitaCorretta) tempoBonus += 5;
            if (quantitaCorretta) punti += 5; // 5 punti per la quantità giusta
        GameManager.Instance.AggiungiTempo(tempoBonus);
            return tipoCorretto || quantitaCorretta;
            
        }
        return true;
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