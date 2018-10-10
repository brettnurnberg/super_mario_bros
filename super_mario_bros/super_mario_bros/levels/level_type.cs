/*********************************************************************
*
*   Class:
*       level_type
*
*   Description:
*       Contains the data for a single level
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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

public abstract class level_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  mario_type              mario;
public  map_type                map;
public  List<character_type>    enemies;
public  int                     time_initial;
public  int                     time_current;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       level_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public level_type()
{
enemies = new List<character_type>();
mario = new mario_type();

} /* level_type() */


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draw the level.
*
***********************************************************/

public abstract void draw( SpriteBatch s );


}
}
