using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogo
{

    [SerializeField]
    private TextoDialogo[] _frases;

    public TextoDialogo[] GetFrases()
    {
        return _frases;
    }

}
