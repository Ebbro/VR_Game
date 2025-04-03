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
    private int ordineCorrente = 0;

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
        ordineCorrente = ordini.Count - 1;
        AggiornaTestoOrdine();
    }

    public bool ControllaOrdine(string tipo, int quantita)
    {
        if (ordini.Count > 0 && ordini[ordineCorrente].tipo == tipo && ordini[ordineCorrente].quantita == quantita)
        {
            ordini.RemoveAt(ordineCorrente);
            ordineCorrente = Mathf.Clamp(ordineCorrente, 0, ordini.Count - 1);
            
            if (ordini.Count == 0)
                ordineText.text = "Nessun ordine disponibile";
            else
                GeneraNuovoOrdine();
            
            return true;
        }
        return false;
    }

    private void AggiornaTestoOrdine()
    {
        if (ordini.Count > 0)
            ordineText.text = $"Tipo: {ordini[ordineCorrente].tipo}\nQuantità: {ordini[ordineCorrente].quantita}";
        else
            ordineText.text = "Nessun ordine disponibile";
    }
}