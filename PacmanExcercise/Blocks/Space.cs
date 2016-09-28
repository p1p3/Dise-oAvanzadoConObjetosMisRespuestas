using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanExcercise.Actors;

namespace PacmanExcercise.Blocks
{
    public class Space : ConstructionBlockType
    {
        #region Overrides of ConstructionBlockType

        public override Point nextPositionForGoingGhost(Ghost ghost, Point aMovement)
        {
            return ghost.position().plus(aMovement);
        }

        public override Point nextPositionForGoingPacman(Pacman pacman, Point aMovement)
        {
            return pacman.position().plus(aMovement).plus(aMovement);
        }


        #endregion
    }
}
