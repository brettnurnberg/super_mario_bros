/*********************************************************************
*
*   Class:
*       model_type
*
*   Description:
*       Contains the game data
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

public class model_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  level_type          level;
public  int                 life_count;
public  int                 score;
public  game_status_enum    game_status;
public  pipe_status_enum    pipe_status;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       model_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public model_type()
{
level = new level_1_1_type();
game_status = game_status_enum.gameplay;
pipe_status = pipe_status_enum.ENTER;
} /* model_type() */

}
}
