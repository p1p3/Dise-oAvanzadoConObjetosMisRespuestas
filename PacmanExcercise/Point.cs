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

using System;

namespace PacmanExcercise
{
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        override public bool Equals(Object anObject){
		if(anObject==null) return false;
		return (anObject.GetType()==typeof(Point)) && equalsPoint((Point) anObject);
	    }

        public override int GetHashCode()
        {
            return _x + _y;
        }


        public bool equalsPoint(Point aPoint)
        {
            return _x == aPoint.x() && _y == aPoint.y();
        }

        public int x()
        {
            return _x;
        }

        public int y()
        {
            return _y;
        }

        public Point plus(Point aPoint)
        {
            return new Point(_x + aPoint.x(), _y + aPoint.y());
        }

    }
}
