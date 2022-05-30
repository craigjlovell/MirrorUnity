using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QuickStart
{
    public class SceneScript : NetworkBehaviour
    {
        public Text canvasStatusText;
        public PlayerScript playerScript;
        public SceneReference scriptReference;

        [SyncVar(hook = nameof(OnStatusTextChanged))]
        public string statusText;

        public Text canvasAmmoText;

        void OnStatusTextChanged(string a_old, string a_new)
        {
            //called from sync var hook, to update info on screen for all players
            canvasStatusText.text = statusText;
        }

        public void ButtonSendMessage()
        {
            if (playerScript != null)
                playerScript.CmdSendPlayerMessage();
        }

        public void ButtonChangeScene()
        {
            if (isServer)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "MyScene")
                    NetworkManager.singleton.ServerChangeScene("MyOtherScene");
                else
                    NetworkManager.singleton.ServerChangeScene("MyScene");
            }
            else
                Debug.Log("You are not Host.");
        }

        public void UIAmmo(int _value)
        {
            canvasAmmoText.text = "Ammo: " + _value;
        }
    }
}
