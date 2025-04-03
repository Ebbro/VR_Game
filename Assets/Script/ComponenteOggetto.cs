using UnityEngine;

public class ComponenteOggetto : MonoBehaviour
{
    public string tipo;
    public int quantita;

    // Metodo per impostare i valori quando necessario
    public void ImpostaValori(string nuovoTipo, int nuovaQuantita)
    {
        tipo = nuovoTipo;
        quantita = nuovaQuantita;
    }
}