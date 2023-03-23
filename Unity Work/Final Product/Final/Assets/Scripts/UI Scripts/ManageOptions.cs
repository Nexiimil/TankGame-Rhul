using UnityEngine;
using UnityEngine.UI;

public class ManageOptions : MonoBehaviour
{
    [SerializeField] private Text[] options; //a list of all options
    [SerializeField] private int current = 0;   //currently active index

    public int Current { get => current; set => current = value; }
    public Text[] Options { get => options; set => options = value; }

    void Update() //Update is called once per frame
    {
        if(Input.GetKeyUp("down")){ //navigates down an index, to a lower option
            Navigate(-1);   //modifies the index by -1
        }
        if(Input.GetKeyUp("up")){   //navigates down an index, to a lower option
            Navigate(1);     //modifies the index by 1
        }
    }

    void Navigate(int i){   //Determines which option is selected at any given index
        string active = " - ";  //the string denoting an active choice
        int limit = Options.Length;    //i can give this class to several objetcs, possibly with more options

        Text option = Options[Current];  //pulls out the text for handling

        if(option.text.Substring(0,3) == active){ //if the option is active
            option.text = option.text.Substring(3); //remove the active marker
        }
        Current = (Current + i + limit) % limit; //change the current choice index
        option = Options[Current]; //isolate the active option
        option.text = active + option.text; //append the active marker to the option
    }
}