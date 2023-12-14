using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AbrirDesafio : MonoBehaviour
{

    public string nomeDesafio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            carregarJanelaDesafio();
        }
    }

    private void carregarJanelaDesafio(){
        SceneManager.LoadScene(nomeDesafio);
    }
}
