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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacmanExcercise.Actors;
using PacmanExcercise.Blocks;


namespace PacmanExcercise
{
    [TestClass]
    public class TestPacman
    {
        protected Actor Pacman;
        protected Actor BlueGhost;
        protected ConstructionBlockType WallType;
        protected ConstructionBlockType SpaceType;
        protected ConstructionBlockType LeftTransporterType;
        protected ConstructionBlockType GhostHouseDoorType;

        protected Point Left;
        protected Point Right;
        protected Point Up;
        protected Point Down;

        [TestInitialize]
        public void SetUp()
        {
            Left = new Point(-1, 0);
            Right = new Point(1, 0);
            Up = new Point(0, 1);
            Down = new Point(0, -1);

            var initialPoint = new Point(0, 0);
            BlueGhost = new Ghost(initialPoint);
            Pacman = new Pacman(initialPoint);

            WallType = new Wall();
            SpaceType = new Space();
            LeftTransporterType = new Teleport();
            GhostHouseDoorType = new GhostHouse();
        }

        [TestMethod]
        public void TestGhostCanNotGoIntoAWall()
        {
            Assert.AreEqual(
                    BlueGhost.position(),
                    WallType.nextPositionForGoing(BlueGhost, Left));

            Assert.AreEqual(
                    BlueGhost.position(),
                    WallType.nextPositionForGoing(BlueGhost, Right));

            Assert.AreEqual(
                    BlueGhost.position(),
                    WallType.nextPositionForGoing(BlueGhost, Up));

            Assert.AreEqual(
                    BlueGhost.position(),
                    WallType.nextPositionForGoing(BlueGhost, Down));
        }

        [TestMethod]
        public void testPacmanCanNotGoIntoAWall()
        {
            Assert.AreEqual(
                    Pacman.position(),
                    WallType.nextPositionForGoing(Pacman, Left));

            Assert.AreEqual(
                    Pacman.position(),
                    WallType.nextPositionForGoing(Pacman, Right));

            Assert.AreEqual(
                    Pacman.position(),
                    WallType.nextPositionForGoing(Pacman, Up));

            Assert.AreEqual(
                    Pacman.position(),
                    WallType.nextPositionForGoing(Pacman, Down));
        }

        [TestMethod]
        public void testPacmanMovesIntoSpacesVeryFast()
        {
            Assert.AreEqual(
                    Pacman.position().plus(new Point(-2, 0)),
                    SpaceType.nextPositionForGoing(Pacman, Left));

            Assert.AreEqual(
                    Pacman.position().plus(new Point(2, 0)),
                    SpaceType.nextPositionForGoing(Pacman, Right));

            Assert.AreEqual(
                    Pacman.position().plus(new Point(0, 2)),
                    SpaceType.nextPositionForGoing(Pacman, Up));


            Assert.AreEqual(
                    Pacman.position().plus(new Point(0, -2)),
                    SpaceType.nextPositionForGoing(Pacman, Down));

        }

        [TestMethod]
        public void testGhostMovesIntoSpacesSlowly()
        {

            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(-1, 0)),
                    SpaceType.nextPositionForGoing(BlueGhost, Left));

            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(1, 0)),
                    SpaceType.nextPositionForGoing(BlueGhost, Right));


            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(0, 1)),
                    SpaceType.nextPositionForGoing(BlueGhost, Up));

            Assert.AreEqual(
                      BlueGhost.position().plus(new Point(0, -1)),
                      SpaceType.nextPositionForGoing(BlueGhost, Down));
        }

        [TestMethod]
        public void testGhostCanEnterHisHouse()
        {
            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(-1, 0)),
                    GhostHouseDoorType.nextPositionForGoing(BlueGhost, Left));

            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(1, 0)),
                    GhostHouseDoorType.nextPositionForGoing(BlueGhost, Right));

            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(0, 1)),
                    GhostHouseDoorType.nextPositionForGoing(BlueGhost, Up));

            Assert.AreEqual(
                    BlueGhost.position().plus(new Point(0, -1)),
                    GhostHouseDoorType.nextPositionForGoing(BlueGhost, Down));
        }

        [TestMethod]
        public void testPacmanCanNotEnterGhostHouse()
        {
            Assert.AreEqual(
                    Pacman.position(),
                    GhostHouseDoorType.nextPositionForGoing(Pacman, Left));

            Assert.AreEqual(
                    Pacman.position(),
                    GhostHouseDoorType.nextPositionForGoing(Pacman, Right));

            Assert.AreEqual(
                    Pacman.position(),
                    GhostHouseDoorType.nextPositionForGoing(Pacman, Up));

            Assert.AreEqual(
                    Pacman.position(),
                    GhostHouseDoorType.nextPositionForGoing(Pacman, Down));
        }

        [TestMethod]
        public void testTransporterMovesPacmanToNewPosition()
        {
            Assert.AreEqual(
                    new Point(10, 4),
                    LeftTransporterType.nextPositionForGoing(Pacman, Left));

            Assert.AreEqual(
                    new Point(10, 4),
                    LeftTransporterType.nextPositionForGoing(Pacman, Right));
        }

        [TestMethod]
        public void testGhostCanNotGoIntoTransporter()
        {
            Assert.AreEqual(
                    BlueGhost.position(),
                    LeftTransporterType.nextPositionForGoing(BlueGhost, Left));

            Assert.AreEqual(
                    BlueGhost.position(),
                    LeftTransporterType.nextPositionForGoing(BlueGhost, Right));
        }


    }
}
