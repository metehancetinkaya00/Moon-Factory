using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonscrpt : MonoBehaviour
{
    public int scenee;
    public void next()
    {
        SceneManager.LoadScene(scenee);
    }
}
