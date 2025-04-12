using System.Collections;
using UnityEngine;

public class GestioneManagerOrdini : MonoBehaviour
{
    public float delayBetweenStarts = 10f;  // Ritardo tra l'avvio di ciascun manager

    private void Start()
    {
        StartCoroutine(AvviaManagerInSequenza());
    }

    private IEnumerator AvviaManagerInSequenza()
    {
        // Trova tutti i figli del sequencer (assicurati che siano manager ordini!)
        Transform[] managerObjects = GetComponentsInChildren<Transform>();

        foreach (Transform managerTransform in managerObjects)
        {
            // Saltare il primo (il sequencer stesso) perché è il parent
            if (managerTransform == transform) continue;

            // Cerca il componente MonoBehaviour di tipo ManagerOrdini o simile
            MonoBehaviour managerScript = managerTransform.GetComponent<MonoBehaviour>();

            // Assicurati che ci sia uno script da abilitare
            if (managerScript != null)
            {
                managerScript.enabled = true;
                Debug.Log($"[OrdiniSequencer] Avviato: {managerScript.GetType().Name} su {managerTransform.name}");
            }

            // Aspetta il tempo specificato prima di attivare il prossimo manager
            yield return new WaitForSeconds(delayBetweenStarts);
        }
    }
}