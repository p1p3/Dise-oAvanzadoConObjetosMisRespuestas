using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacmanExcercise.Actors;

namespace PacmanExcercise.Blocks
{
    public class Teleport : ConstructionBlockType
    {
        #region Overrides of ConstructionBlockType

        public override Point nextPositionForGoingGhost(Ghost ghost, Point aMovement)
        {
            return ghost.position();
        }

        public override Point nextPositionForGoingPacman(Pacman pacman, Point aMovement)
        {
            return new Point(10, 4);
        }

        #endregion
    }
}
