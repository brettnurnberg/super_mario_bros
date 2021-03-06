/*********************************************************************
*
*   Class:
*       Marios
*
*   Description:
*       Static list of all mario sprites
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

public static class Marios {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

static public Texture2D[]  textures;

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

static Marios()
{
textures = new Texture2D[(int)mario_enum.COUNT];

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
int count = (int)mario_enum.COUNT;

for( int i = 0; i < count; i++ )
    {
    textures[i] = c.Load<Texture2D>( String.Format( "mario_" + i ) );
    }

} /* load_content() */


}
}
