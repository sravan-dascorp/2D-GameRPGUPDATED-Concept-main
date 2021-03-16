using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;

    public class questionclick : MonoBehaviour
    {
        // Start is called before the first frame update
        public static bool spacebuuttoncliced = false;
       
        public Quest quest;
        //public GameObject popup;
        
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void spacebuttonemmulate()
        {
            spacebuuttoncliced = true;
        }
        public void Right_answer()
        {

            quest.questionAnswered = true;
        quest.temporaryfix();
        this.gameObject.SetActive(false);
    }
        public void Wrong_answer()
        {
            quest.wronganswerclicked();
       
        this.gameObject.SetActive(false);
        
        }

        }
