using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using static UnityEngine.Rendering.GPUSort;

public class ToyPiece : MonoBehaviour
{

    [SerializeField] public int NumberOfPieces = 1;
    [SerializeField] private List<GameObject> Pieces = new List<GameObject>();

    [SerializeField] private bool IsBase=false;
    [SerializeField] private List<string> ToyTypes = new List<string>();

    [SerializeField] private string PieceType = null;

    [SerializeField] private List<XRSocketInteractor> socket = new List<XRSocketInteractor>();



    private void Awake()
    {

        //ActivateSocketListeners();
    }


    private void ActivateSocketListeners()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            socket.Add(transform.GetChild(i).GetComponent<XRSocketInteractor>());
            socket[i] = transform.GetChild(i).GetComponent<XRSocketInteractor>();
            socket[i].selectEntered.AddListener(OnObjectInserted);
            socket[i].selectExited.AddListener(OnObjectRemoved);
        }
    }
    private void OnObjectInserted(SelectEnterEventArgs obj)
    {
        Debug.Log("Object enetered socket");
        GameObject piece = obj.interactableObject.transform.gameObject;
        Debug.Log(piece.name);
        AddPiaceToList(piece);

    }

    private void OnObjectRemoved(SelectExitEventArgs obj)
    {
        Debug.Log("Object exited socket");
        GameObject piece = obj.interactableObject.transform.gameObject;
        RemovePiaceToList(piece);
    }


    private void AddPiaceToList(GameObject obj)
    {
        if (IsBase)
        {
            Pieces.Add(obj);
            NumberOfPieces++;
    
            if(obj.GetComponent<ToyPiece>().PieceType != null)
            {
                ToyTypes.Add(obj.GetComponent<ToyPiece>().PieceType);
            }
            
        }
    }

    private void RemovePiaceToList(GameObject obj)
    {
        for (int i = 0;i < Pieces.Count; i++)
        {
            if (Pieces[i].gameObject == obj) Pieces.Remove(Pieces[i]);
            NumberOfPieces--;   
        }
    }

    private void ActivateToyPiece()
    {
        transform.tag = "Attachable";
    }


    private void DeactivateToyPiece()
    {
        transform.tag = "Defualt";
    }

    private void AddToMerged()
    {
        /*if (IsBase) {
            Pieces.Add()
            Types.Add
                }*/
    }


    private void SetInteractionManager(GameObject InteractionManager) {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<XRSocketInteractor>().interactionManager = InteractionManager.GetComponent<XRInteractionManager>();
        }


    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameObject InteractionManager = GameObject.FindGameObjectWithTag("InteractionManager");
        ActivateSocketListeners();

    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
