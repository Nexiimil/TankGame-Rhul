using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private List<Stats> _sa = new List<Stats>();
    [SerializeReference] private List<IEffect> _ef = new List<IEffect>();
    [SerializeField] private List<Affliction> _af = new List<Affliction>();
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool tick = true;

    public List<IEffect> Ef { get => _ef; set => _ef = value; }
    public List<Stats> Sa { get => _sa; set => _sa = value; }
    public List<Affliction> Af { get => _af; set => _af = value; }
    public bool Tick { get => tick; set => tick = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    void Awake(){
      Sa.Clear();
      Ef.Clear();
      Af.Clear();
      Sa = new List<Stats>{
        new Stats("BulletType", 0, 0),
        new Stats("BulletDamage", 1, 0),
        new Stats("BulletSpeed", 10, 0),
        new Stats("BulletCrit", 0, 0),
        new Stats("EntityArmor", 0, 0),
        new Stats("EntitySpeed", 2, 0),
        new Stats("EntityFireSpeed", 1, 0),
        new Stats("EntityRoSpeed", 75, 0),
        new Stats("MaxHealth", 5, 0),
        new Stats("Cannons", 1, 0)
      };
    }

    void Update()
    {
        if (Tick == true && Af.Count > 0)
        {
            StartCoroutine(AfflictionTick());
        }
    }

    IEnumerator AfflictionTick()
    {
        Tick = false;
        List<Affliction> clone = new(Af);
        foreach (Affliction af in clone)
        {
            af?.Afflict(gameObject);
            af.Time--;
            if (af.Time <= 0)
            {
                af.Restore(gameObject);
                Af.Remove(af);
            }
        }
        yield return new WaitForSeconds(1);
        Tick = true;
    }
}
