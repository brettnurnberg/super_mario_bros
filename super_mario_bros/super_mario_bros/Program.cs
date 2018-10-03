﻿/*********************************************************************
*
*   Class:
*       Program
*
*   Description:
*       The main class for the application. Contains
*       the entry point.
*
*   TODO:
*       fix pipe entry (only enter if holding left and on ground)
*       fix pipe entry (zero velocity and acceleration)
*       add pipe animation
*       Add block behavior (on hit)
*           have items come out of the block
*       Add item implementation (mushroom, flower, coin, star, 1-up)
*       Draw castle at end
*       Create flag pole implementation
*       add enemies
*       add mario sounds
*       add music
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using System;

/*--------------------------------------------------------------------
                           NAMESPACE
--------------------------------------------------------------------*/

namespace super_mario_bros {

/*--------------------------------------------------------------------
                           DELEGATES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                             CLASS
--------------------------------------------------------------------*/

public static class Program {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/
public static model_type        model;
public static view_type         view;
public static controller_type   controller;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       Main
*
*   Description:
*       Entry point for the application.
*
***********************************************************/

[STAThread]
static void Main()
{
model      = new model_type();
controller = new controller_type( model );
view       = new view_type( model );

using ( Game1 game = new Game1( model, controller, view ) )
    {
    game.Run();
    }

} /* Main() */


}
}
