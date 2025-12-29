using System.IO.Pipes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    private Animator _anim;
    public bool isMenu = false;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMenu == true)
        {
            firstButton.gameObject.SetActive(!firstButton);
            secondButton.gameObject.SetActive(secondButton);
        }
        else if (isMenu == false)
        {
            firstButton.gameObject.SetActive(firstButton);
            secondButton.gameObject.SetActive(!secondButton);
        }
    }

    public void MenuOpen()
    {
        isMenu = !isMenu;
        _anim.SetBool("isMenu", isMenu);
    }
}
