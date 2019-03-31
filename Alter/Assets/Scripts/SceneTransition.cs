using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public void Transition(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}
