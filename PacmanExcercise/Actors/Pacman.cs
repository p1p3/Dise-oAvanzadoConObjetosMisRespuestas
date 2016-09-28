using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanExcercise.Actors
{
    public class Pacman : Actor
    {
        private Point actualPosition;
        public Pacman(Point initialPosition)
        {
            actualPosition = initialPosition;
        }

        #region Overrides of Actor

        public override Point position()
        {
            return actualPosition;
        }


        #endregion
    }
}
