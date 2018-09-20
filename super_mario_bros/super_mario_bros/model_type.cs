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

public  level_type  level;
public  int         life_count;
public  int         score;

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
level = new level_type();
} /* model_type() */

//temp
public void temp_load( ContentManager c )
{
level.temp_load( c );
} /* model_type() */

}
}
