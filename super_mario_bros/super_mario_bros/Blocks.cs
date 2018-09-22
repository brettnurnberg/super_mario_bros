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

static public Texture2D[]  textures;
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
textures = new Texture2D[(int)block_enum.BLOCK_COUNT];

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
int count = (int)block_static_enum.BLOCK_COUNT;

for( int i = 1; i < count; i++ )
    {
    textures[i] = c.Load<Texture2D>( String.Format( "static_block_" + i ) );
    }
for( int i = 0; i < (int)block_enum.BLOCK_COUNT - count; i++ )
    {
    textures[ count + i ] = c.Load<Texture2D>( String.Format( "block_" + i ) );
    }

} /* load_content() */


}
}
