using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mascarando : MonoBehaviour
{
    public int num_mascaras = 3;
    private Vector2 maskposition;
    public Rigidbody2D rb;

    public GameObject virus1, virus2, virus3;
    
    bool acertei(){
        Vector2 faceposition = rb.transform.position;
        if (Vector2.Distance(faceposition, maskposition) < 2f) return true;
        return false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        num_mascaras = 3;
        rb = GameObject.Find("mila").GetComponent<Rigidbody2D> ();
        maskposition = new Vector2(-0.13f,0.04f);
        
        virus1 = GameObject.Find("virus1");
        virus1.SetActive(false);
        virus2 = GameObject.Find("virus2");
        virus2.SetActive(false);
        virus3 = GameObject.Find("virus3");
        virus3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            var audios = GetComponents<AudioSource>();
            
            
            if (acertei()) {
                num_mascaras = 3;
                audios[1].Play();
                virus1.SetActive(false);
                virus2.SetActive(false);
                virus3.SetActive(false);
                Debug.Log("Acertou");
            } else {
                audios[0].Play();
                num_mascaras -= 1;
            }
        }

        if (num_mascaras <= 2)
            virus1.SetActive(true);

        if (num_mascaras <= 1)
            virus2.SetActive(true);

        if (num_mascaras == 0){
            virus3.SetActive(true);
            SceneManager.LoadScene("FimdoJogo");
            Debug.Log("Acabou o jogo");
        }

    
    }
}
