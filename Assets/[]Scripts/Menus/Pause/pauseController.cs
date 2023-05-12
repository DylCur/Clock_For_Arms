using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{

    public bool isPaused;
    public GameObject pauseMenu;
    playerController playerControl;
    attackController attackControl;
   
    [Header("Holders")]

    [SerializeField] GameObject player;
    [SerializeField] GameObject attackControlHolder;

    [Header("KeyCodes")]

    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    


    void Start(){
        playerControl = player.GetComponent<playerController>();
        attackControl = attackControlHolder.GetComponent<attackController>();
        pauseMenu.SetActive(false);
    
    }

    void update(){
        if(Input.GetKeyDown(pauseKey)){
            Debug.Log("PauseKey");
            
            pauseGame();
        }
    }


    public void pauseGame()
    {

        Debug.Log("Pause");


        if(!isPaused){
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
            
        }

        else{
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
            
        }

        
    }
    
    
    
}




