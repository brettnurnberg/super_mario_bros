/*********************************************************************
*
*   Class:
*       block_type
*
*   Description:
*       Contains the data for a single block
*
*   Can contain behavior for hit from any side
*   Can contain list of textures as necessaru
*   Can contain draw method
*   Should there be a static list of blocks?
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

public abstract class block_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given block.
*
***********************************************************/

public abstract void draw( SpriteBatch s, int x, int y );


/***********************************************************
*
*   Method:
*       hit_bottom
*
*   Description:
*       Behavior on hitting the bottom of the block.
*       Returns true if the block is immobile.
*
***********************************************************/

public abstract Boolean hit_bottom();


/***********************************************************
*
*   Method:
*       hit_side
*
*   Description:
*       Behavior on hitting the side of the block.
*
***********************************************************/

public abstract void hit_side();


}
}
