using UnityEngine;

public class MultiValueForRewind
{

    public Vector2 positions;

    //used when rewinding animations, we will use Animation.Rewind for it, these are just to keep track of when we are playing an animation 
    public float speed;
    public bool jump;
    

    public MultiValueForRewind (Vector2 _positions, float _speed, bool _jump)
    {
        positions = _positions;
        speed = _speed;
        jump = _jump;
    }
}
