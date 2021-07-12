using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TradeScenes : MonoBehaviour
{
    public string nomedaCena;

    //Troca a cena qnd encosta no objeto com a tag Completed
    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.transform.CompareTag("Completed"))
        {
            SceneManager.LoadScene(nomedaCena);
        }
    }
}
