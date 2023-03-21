using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private string loadScenesString;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            Debug.Log("Well done. You are going to the next level. ");
            SceneManager.LoadScene(loadScenesString);
            NewPlayer.Instance.SetSpawnPosition();
        }
    }
}
