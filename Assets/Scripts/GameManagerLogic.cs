using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text StageItemText;
    public Text GetItemText;

    private void Awake()
    {
        StageItemText.text = "/ " + totalItemCount;
    }
    public void GetItem(int count)
    {
        GetItemText.text = count.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (stage == 0)
                SceneManager.LoadScene(0);
            else if (stage == 1)
                SceneManager.LoadScene(1);
            else if (stage == 2)
                SceneManager.LoadScene(2);
        }
            
    }
}
