using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNCreator
{
    public class MinigamePlayer : MonoBehaviour
    {
        public GameObject CleaningMinigame;
        public GameObject SavingMinigame;

        public GameObject VisualNovel;
    
        public VNCreator_DisplayUI ui;

        public void PlayCleaning()
        {
            VisualNovel.SetActive(false);
            CleaningMinigame.SetActive(true);

        }

        public void PlaySaving()
        {
            VisualNovel.SetActive(false);
            SavingMinigame.SetActive(true);
        }

        public void returnToVN()
        {
            VisualNovel.SetActive(true);
            ui.ForceNextNode(0);
        }
    }
}