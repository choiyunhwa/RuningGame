using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextControl textControl;
    public ButtonControl buttonControl;
    // Start is called before the first frame update
    void Awake(){
        textControl = GetComponent<TextControl>();
        buttonControl = GetComponent<ButtonControl>();
    }
    void Start()
    {
        textControl.SetStartPanel();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
