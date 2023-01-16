using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageOptions : MonoBehaviour
{
    [SerializeField] private Text[] options; //a list of all options
    [SerializeField] private int current = 0;   //currently active index

    public void setOptions(Text[] options){this.options = options;} //sets the list of text options
    public Text[] getOptions(){return this.options;} //fetches the the full list of options
    public Text getOption(int current){return this.options[current];} //fetches a specific option
    public void setCurrent(int current){this.current = current;} //sets the current active option index
    public int getCurrent(){return this.current;} //fetches the current active option index

    void Start() //ran at object creation
    {
        Navigate(2); //Must provide an intial index for the option arrays
    }

    void Update() //Update is called once per frame
    {
        if(Input.GetKeyUp("down")){ //navigates down an index, to a lower option
            Navigate(-1);   //modifies the index by 1
        }
        if(Input.GetKeyUp("up")){   //navigates down an index, to a lower option
            Navigate(1);     //modifies the index by 1
        }
    }

    void Navigate(int i){   //Determines which option is selected at any given index
        string active = " - ";  //the string denoting an active choice
        int limit = getOptions().Length;    //i can give this class to several objetcs, possibly with more options

        Text option = getOption(getCurrent());  //pulls out the text for handling

        if(option.text.Substring(0,3) == active){ //if the option is active
            option.text = option.text.Substring(3); //remove the active marker
        }
        setCurrent((getCurrent() + i + limit) % limit); //change the current choice index
        option = getOption(getCurrent()); //isolate the active option
        option.text = active + option.text; //append the active marker to the option
    }
}