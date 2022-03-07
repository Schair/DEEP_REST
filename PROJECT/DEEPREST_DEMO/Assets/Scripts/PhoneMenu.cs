using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PhoneMenu : MonoBehaviour
{
    [SerializeField] private bool canOpenMenu;
    [SerializeField] private Animator menuAnimation;
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private TextMeshProUGUI bigClock;
    private bool menuState;
    void Start()
    {
        CheckCanOpenMenu();
    }

    void Update()
    {
        CheckCanOpenMenu();
        if(canOpenMenu){
            CheckPhoneInput();
            PhoneClock();
        }
    }

    private void CheckCanOpenMenu(){
        canOpenMenu = GameInfoIO.ReadPhone() == "1" ? true : false;
    }

    private void CheckPhoneInput(){
        if(menuState && Input.GetButtonDown("Pause")){
            CloseMenu();
        } else if(Input.GetButtonDown("Pause")){
            OpenMenu();
        }
    }

    public void OpenMenu(){
        menuAnimation.SetBool("MenuOpen", true);
        menuState = menuAnimation.GetBool("MenuOpen");
    }

    public void CloseMenu(){
        menuAnimation.SetBool("MenuOpen", false);
        menuState = menuAnimation.GetBool("MenuOpen");
    }

    private void PhoneClock(){
        clock.text = DateTime.Now.ToString("HH:mm");
        bigClock.text = DateTime.Now.ToString("HH:mm");
    }
}
