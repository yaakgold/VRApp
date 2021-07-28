using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.tag == "finalBox")
        {
            SceneManager.LoadScene(1);
        }
    }
}
