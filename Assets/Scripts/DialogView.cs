using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    [SerializeField] Text _message = null;
    public event Action OnPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Show(string message){
        _message.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            OnPressed?.Invoke();
        }
    }

    
}
