using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tommy Tran
//6/06/2022
//Version 2019.4.29
public class TutorialTransition : MonoBehaviour
{
    //Changes the Scene to the first stage
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
