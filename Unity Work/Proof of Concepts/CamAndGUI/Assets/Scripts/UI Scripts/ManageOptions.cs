using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageOptions : MonoBehaviour
{
    [SerializeField] private Text[] options;
    [SerializeField] private int current = 0;

    public void setOptions(Text[] options){this.options = options;}
    public Text[] getOptions(){return this.options;}

    public Text getOption(int current){return this.options[current];}

    public void setCurrent(int current){this.current = current;}
    public int getCurrent(){return this.current;}

    void Start()
    {
        Navigate(2);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("down")){
            Navigate(-1);
        }
        if(Input.GetKeyUp("up")){
            Navigate(1);
        }
    }
    void Navigate(int i){
        string active = " - ";
        int limit = getOptions().Length;

        Text option = getOption(getCurrent());

        if(option.text.Substring(0,3) == active){
            option.text = option.text.Substring(3);
        }
        setCurrent((getCurrent() + i + 3) % limit);
        option = getOption(getCurrent());
        option.text = active + option.text;
    }
}
