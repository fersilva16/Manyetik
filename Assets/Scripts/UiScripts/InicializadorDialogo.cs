using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InicializadorDialogo : MonoBehaviour
{
    [SerializeField]
    private GerenciadorDeDialogo _gerenciador;
    [SerializeField]
    private Dialogo _dialogo;

    public void Inicializa()
    {
        if (_gerenciador == null)
            return;
         _gerenciador.Inicializa(_dialogo);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Inicializa();
        }
    }
}
