using UnityEngine;

[CreateAssetMenu(menuName ="Player", fileName = "Default")]
public class PlayerData : ScriptableObject
{
    public int FluelLevel;
    public int HP;
    public int DamageForce;
    public int DamageTime;
    public int PowerTurbo;
    public int PowerTurn;

}
