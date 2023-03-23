using System.IO;
using UnityEngine;

public interface IEffect
{
    float ChancePMod { get; set; }
    string[] StatsModified { get; set; }

    public IEffect RollAfflictionChance(){
        System.Random rng = new System.Random();
        if((rng.Next(0,10))/100 < this.ChancePMod){
            return this;
        }else{
            return null;
        }
    }

    public void Aggregate(IEffect aggragate); 
    public void Negate();
    public void Afflict(GameObject go, GameObject aff);

    public string ToString();
    public int ExpireCalc();

    public static Sprite GetImage(IEffect e){
        string dir =  System.IO.Directory.GetCurrentDirectory() + "/Effects/" + e.GetType().ToString() + ".png";
        byte[] spriteData = File.ReadAllBytes(dir);
        Texture2D texture2D = new Texture2D(2,2);
        texture2D.LoadImage(spriteData);
        texture2D.filterMode = FilterMode.Point;
        return(Sprite.Create(texture2D, new Rect(0,0,16,16),new Vector2(0.5f,0.5f), 16f));
    }
}