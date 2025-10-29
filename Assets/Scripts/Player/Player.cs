using UnityEngine;

public class Player : MonoBehaviour
{
    private const double _MAX_SPEED = 200;
    private double Speed { get => Speed; set => Speed = value; }
    private double Momentum { get => Momentum; set => Momentum = Momentum; }
    private double JumpHeigth { get => JumpHeigth; set => JumpHeigth = JumpHeigth; }
}
