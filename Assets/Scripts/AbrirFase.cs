using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AbrirFase : MonoBehaviour
{

    public string nomeFase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            carregarFase();
        }
    }

    private void carregarFase(){
        SceneManager.LoadScene(nomeFase);
    }
}
