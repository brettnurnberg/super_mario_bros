/*********************************************************************
*
*   Class:
*       Blocks
*
*   Description:
*       Static list of all blocks
*
*       I don't believe this will work for behavioral blocks
*       The behavioral blocks will all point to the same object,
*       causing them to all share behavior
*
*       But it MAY work for creating loading all block textures
*       Would we just want a static list of all block textures, not block types??
*
*       Also create static list of character textures - could have list for each character type
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

public static class Blocks {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

static public block_type[] list;
static public Rectangle    size;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       Blocks
*
*   Description:
*       Constructor.
*
***********************************************************/

static Blocks()
{
list = new block_type[(int)block_enum.BLOCK_COUNT];

list[(int)block_enum.EMPTY]      = null;
list[(int)block_enum.RED_COBBLE] = new block_red_cobble_type();

size.Width = 16;
size.Height = 16;

} /* Blocks() */


/***********************************************************
*
*   Method:
*       load_content
*
*   Description:
*       Loads all images for all blocks.
*
***********************************************************/

static public void load_content( ContentManager c )
{

for( int i = 1; i < (int)block_enum.BLOCK_COUNT; i++ )
    {
    list[i].load_content( c );
    }

} /* load_content() */


}
}
