/*
 * Developed by 10Pines SRL
 * License: 
 * This work is licensed under the 
 * Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/3.0/ 
 * or send a letter to Creative Commons, 444 Castro Street, Suite 900, Mountain View, 
 * California, 94041, USA.
 *  
 */

using PacmanExcercise.Actors;

namespace PacmanExcercise
{
    public abstract class ConstructionBlockType
    {
        public Point nextPositionForGoing(Actor anActor, Point aMovement)
        {
            return anActor.moveToBlockType(this, aMovement);

        }

        public abstract Point nextPositionForGoingGhost(Ghost ghost, Point aMovement);

        public abstract Point nextPositionForGoingPacman(Pacman pacman, Point aMovement);


    }
}
