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
using System.Collections;

namespace StackExercise
{
    class Stack
    {
        public static String STACK_EMPTY_DESCRIPTION = "Stack is Empty";

        private Item lastItem;

        public Stack()
        {
            lastItem = new FirstItemOfStack();
        }

        public void push(Object anObject)
        {
            var nextObject = new ItemOfStack(lastItem, anObject, lastItem.Posicion() + 1);
            lastItem = nextObject;
        }

        public Object pop()
        {
            var objectToReturn = lastItem.Contenido();
            lastItem = lastItem.Anterior();
            return objectToReturn;
        }

        public Object top()
        {
            return lastItem.Contenido();
        }

        public bool isEmpty()
        {
            return lastItem.isEmpty();
        }

        public int size()
        {
            return lastItem.Posicion();
        }
    }
}
