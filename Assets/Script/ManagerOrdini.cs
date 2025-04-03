using System.Collections.Generic;
using UnityEngine;
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

    public string[] tipiPossibili = { "Pane", "Latte", "Carne", "Frutta", "Verdura" };
    public int minQuantita = 1;
    public int maxQuantita = 10;

    void Start()
    {
        GeneraNuovoOrdine();
    }

    private void GeneraNuovoOrdine()
    {
        string tipo = tipiPossibili[Random.Range(0, tipiPossibili.Length)];
        int quantita = Random.Range(minQuantita, maxQuantita + 1);

        ordini.Add(new ComponenteOrdine(tipo, quantita));
        AggiornaTestoOrdine();
    }

    public void CompletaOrdine()
    {
        if (ordini.Count > 0)
        {
            ordini.RemoveAt(0); // Rimuove il primo ordine
            AggiornaTestoOrdine();

            if (ordini.Count == 0)
            {
                GeneraNuovoOrdine(); // Genera un nuovo ordine solo se la lista è vuota
            }
        }
    }

    private void AggiornaTestoOrdine()
    {
        if (ordini.Count > 0)
            ordineText.text = $"Tipo: {ordini[0].tipo}\nQuantità: {ordini[0].quantita}";
        else
            ordineText.text = "Nessun ordine disponibile";
    }
}