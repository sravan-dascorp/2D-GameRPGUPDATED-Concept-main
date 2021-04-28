using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redeembuttonScript : MonoBehaviour
{
    public GameObject redeemm_panel;
    public GameObject addtoWalletMessage;


    public Text goldredeemtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldredeemtext.text = "You got " + InventorySimple.gold + "  Gold !";
    }

    public void activateredeempanel()
    {
        if (redeemm_panel.activeSelf)
        {
            redeemm_panel.SetActive(false);
        }
        else if  (!redeemm_panel.activeSelf)
            {
                redeemm_panel.SetActive(true);
            }
    }
    public void activateaddtowalletmessage()
    {
        if (addtoWalletMessage.activeSelf)
        {
            addtoWalletMessage.SetActive(false);
        }
        else if (!addtoWalletMessage.activeSelf)
        {
            addtoWalletMessage.SetActive(true);
        }
    }



}
