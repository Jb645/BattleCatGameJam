using UnityEngine;

namespace BattleCat
{
    public class MultiValueForRewind 
    {

        public Vector2 Positions;


        public float lastDirections;

        //used when rewinding animations, we will use Animation.Rewind for it, these are just to keep track of when we are playing an animation 
        public float speed;

        public float moveing;
    

        //used to put them all in one list
        public MultiValueForRewind (Vector2 _positions, float _movement, float _latestdirection)
        {
            Positions = _positions;
            lastDirections = _latestdirection;
            moveing = _movement; 
        }

    }
}
