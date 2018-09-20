/*********************************************************************
*
*   Class:
*       character_type
*
*   Description:
*       Contains data on a single character
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

public abstract class character_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  Vector2             position_initial;
public  Vector2             position;
public  physics_type        physics;
public  Texture2D           sprite;
public  char_dir_enum       direction;
public  char_status_enum    ground_status;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       character_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public character_type()
{

} /* character_type() */


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given character.
*
***********************************************************/

public abstract void draw( SpriteBatch s );


/***********************************************************
*
*   Method:
*       load_content
*
*   Description:
*       Loads content for the given block.
*
***********************************************************/

public abstract void load_content( ContentManager c );


}
}
