using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    [SerializeField] GameOver gameover;
    public void Crash()
    {
        gameover.EndGame(); 
        
        gameObject.SetActive(false);
    }
}
