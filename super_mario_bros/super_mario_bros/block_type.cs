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

public  Texture2D   texture;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       block_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public block_type()
{

} /* block_type() */


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
*       load_content
*
*   Description:
*       Loads content for the given block.
*
***********************************************************/

public abstract void load_content( ContentManager c );


}
}
