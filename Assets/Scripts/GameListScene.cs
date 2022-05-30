using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuickStart
{
    public class GameListScene : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
