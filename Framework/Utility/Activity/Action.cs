using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Utility.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using static Framework.Utility.Share;

namespace Framework.Utility.Activity
{
    public static class Action
    {

        // ************ DATE 10/16/2020 ************
        // In charge of the instantiation of the Action Class
        // ************ --------------- ************
        #region CORE


        /// <summary>
        /// Build a single ITouchAction based on the current driver being used
        /// </summary>
        private static ITouchAction BuildSingleAction()
        {
            return new TouchAction(GlobalVar.AndroidDriver);
        }


        /// <summary>
        /// Build a single IMultiAction based on the current driver being used
        /// </summary>
        private static IMultiAction BuildMultiAction()
        {
            return new MultiAction(GlobalVar.AndroidDriver);
        }


        /// <summary>
        /// Builds a List of ITouchAction based on the current driver being used
        /// </summary>
        /// <param name="quantity"> amount of actions to create </param>
        private static IList<ITouchAction> BuildActions(int quantity)
        {
            IList<ITouchAction> actions = null;

            for(var i =0 ; i < quantity; i ++)
            {
                actions.Add(BuildSingleAction());
            }

            return actions;
        }

        #endregion END OF CORE


        // ************ DATE 10/16/2020 ************
        // In charge of the instantiation of single Action functions
        // ************ --------------- ************
        #region SINGLE ACTION FUNCTIONS


        #region MOVE ACTIONS


        /// <summary>
        /// Emulates the swipe till the end of a specific element over the X & Y axis.
        /// </summary>
        /// <param name="className"> className of the element to swipe </param>
        /// <param name="direction"> represents the Enum in Share class </param>
        /// <param name="duration"> time to wait until swipe to position </param>
        public static void SwipeByClassName(string className, Direction direction = Direction.Up, int duration = 0)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                AppiumWebElement scrollView = GetControl.ByClass(className);

                var initialWidth = scrollView.Size.Width - (scrollView.Size.Width - 5);
                var initialHeight = scrollView.Size.Height - (scrollView.Size.Height - 5);
                var centerWidth = scrollView.Size.Width / 2;
                var centerHeight = scrollView.Size.Height / 2;
                var endWidth = scrollView.Size.Width - 5;
                var endHeight = scrollView.Size.Height - 5;

                switch (direction)
                {
                    case Direction.Up:
                        action.Press(scrollView, centerWidth, initialHeight).Wait(duration).MoveTo(scrollView, centerWidth, endHeight).Release().Perform();
                        break;
                    case Direction.Down:
                        action.Press(scrollView, centerWidth, endHeight).Wait(duration).MoveTo(scrollView, centerWidth, initialHeight).Release().Perform();
                        break;
                    case Direction.Left:
                        action.Press(scrollView, initialWidth, centerHeight).Wait(duration).MoveTo(scrollView, endWidth, centerHeight).Release().Perform();
                        break;
                    case Direction.Right:
                        action.Press(scrollView, endWidth, centerHeight).Wait(duration).MoveTo(scrollView, initialWidth, centerHeight).Release().Perform();
                        break;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("SwipeByClassName threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Swipe from an initial position to an ending position based on the parameters
        /// </summary>
        /// <param name="startX"> initial value on X axis </param>
        /// <param name="startY"> initial value on Y axis </param>
        /// <param name="endX"> ending value on X axis </param>
        /// <param name="endY"> ending value on Y axis </param>
        /// <param name="duration"> time to wait until swipe to position </param>
        public static void SwipeScreen(int startX, int startY, int endX, int endY, int duration = 0)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                action.Press(startX, startY).Wait(duration).MoveTo(endX, endY).Release().Perform();
            }
            catch (Exception ex)
            {
                Assert.Fail("SwipeScreen threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// Moves to a specific position of an element that will be found using it's classname
        /// </summary>
        /// <param name="className"> classname of the element to be found </param>
        /// <param name="x"> value to move on X axis </param>
        /// <param name="y"> value to move on Y axis </param>
        public static void MoveToByClassName(string className, int x, int y)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                AppiumWebElement scrollView = GetControl.ByClass(className);
                action.MoveTo(scrollView, x, y).Perform();

            }
            catch (Exception ex)
            {
                Assert.Fail("MoveToByClassName threw an exception: " + ex.Message);
            }

        }


        #endregion END OF MOVE ACTIONS


        #region TOUCH/TAP ACTIONS


        /// <summary>
        /// Tap over a specific element that will be found using it's classname 
        /// </summary>
        /// <param name="className"> classname of the element to be found </param>
        /// <param name="x"> value to move on X axis </param>
        /// <param name="y"> value to move on Y axis </param>
        /// <param name="duration"> time to wait until swipe to position </param>
        public static void TapByClassName(string className, int x, int y, int duration = 0)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                AppiumWebElement element = GetControl.ByClass(className);
                action.Tap(element, x, y).Wait(duration).Perform();
            }
            catch (Exception ex)
            {
                Assert.Fail("TapByClassName threw an exception: " + ex.Message);
            }

        }


        #endregion END OF TOUCH/TAP ACTIONS


        #region PRESS ACTIONS


        /// <summary>
        /// Press over a specific element that will be found using it's classname.
        /// </summary>
        /// <param name="className"> classname of the element to be found </param>
        /// <param name="duration"> time to wait until swipe to position </param>
        public static void PressByClassName(string className, int duration = 0)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                AppiumWebElement element = GetControl.ByClass(className);
                action.Press(element).Wait(duration).Perform();

            }
            catch (Exception ex)
            {
                Assert.Fail("PressByClassName threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// LongPress over a specific element that will be found using it's classname.
        /// </summary>
        /// <param name="className"> classname of the element to be found </param>
        /// <param name="duration"> time to wait until swipe to position </param>
        public static void LongPressByClassName(string className, int duration = 1)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                AppiumWebElement element = GetControl.ByClass(className);
                action.LongPress(element).Wait(duration).Release().Perform();

            }
            catch (Exception ex)
            {
                Assert.Fail("PressByClassName threw an exception: " + ex.Message);
            }
        }


        /// <summary>
        /// LongPress over a specific element that will be found using it's classname.
        /// Can be used when that element shows a toggle or a popUp if press.
        /// </summary>
        /// <param name="className1"></param>
        /// <param name="className2"></param>
        /// <param name="duration"></param>
        public static void LongPressByClassName(string className1, string className2, int duration = 0)
        {
            ITouchAction action = BuildSingleAction();
            try
            {
                AppiumWebElement firstElem = GetControl.ByClass(className1);
                AppiumWebElement secondElem = GetControl.ByClass(className2);
                action.LongPress(firstElem).Wait(duration).MoveTo(secondElem).Release().Perform();
            }
            catch (Exception ex)
            {
                Assert.Fail("LongPressByClassName threw an exception: " + ex.Message);
            }
        }

        #endregion END OF PRESS ACTIONS


        #endregion END OF SINGLE ACTION FUNCTIONS


        // ************ DATE 10/16/2020 ************
        // In charge of the instantiation of multi Action functions
        // ************ --------------- ************
        #region MULTI ACTION FUNCTIONS


        #region PRESS ACTIONS

        public static void MultiPressByClassName(string className, int duration = 0)
        {
            var multiAction = BuildMultiAction();
            var position = 0;

            try
            {
                var elements = GetControl.CollectionByClass(className);
                var actions = BuildActions(elements.Count());
                
                //Create the press actions for every element found
                foreach (var elem in elements)
                {
                    actions[position].Press(elem).Wait(duration).Release();
                    position++;
                }

                //add every action created before
                for (int i = 0; i < position; i++)
                {
                    multiAction.Add(actions[i]);
                }

                multiAction.Perform();
            }
            catch (Exception ex)
            {
                Assert.Fail("MultiPressByClassName threw an exception: " + ex.Message);
            }

        }


        #endregion END OF PRESS ACTIONS


        #endregion END OF MULTI ACTION FUNCTIONS
    }
}
