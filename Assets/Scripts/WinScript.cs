using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    [SerializeField] private string _nameObj = "Important";
    public GameManager _gamemanager;

    // it will check if the object trigger with the right place
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_nameObj))
        {
            _gamemanager.winNumber++;
            Destroy(gameObject);
            BoxCollider2D _boxcollider = collision.gameObject.GetComponent<BoxCollider2D>();
            _boxcollider.enabled = false;
        }
    }
}
