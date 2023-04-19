using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshButton : MonoBehaviour
{
    public Button btnJump;
    public Button btnAttack;
    public Button btnmask;
    public cshPlayerController sPlayer;
    void Start()
    {
        btnJump.gameObject.SetActive(true);
        btnJump.onClick.RemoveAllListeners();
        btnJump.onClick.AddListener(OnClickJumpButton);
        btnAttack.gameObject.SetActive(false);
        btnAttack.onClick.RemoveAllListeners();
        btnAttack.onClick.AddListener(OnClickAttackButton);
        btnmask.onClick.RemoveAllListeners();
        btnmask.onClick.AddListener(OnClickmaskButton);
    }
    void Update()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        bool canAttack = sPlayer.CanAttack();
        btnAttack.gameObject.SetActive(canAttack);
        btnJump.gameObject.SetActive(!canAttack);
    }
    private void OnClickJumpButton()
    {
        
    }

    private void OnClickAttackButton()
    {
       
    }

    private void OnClickmaskButton()
    {

    }
}
