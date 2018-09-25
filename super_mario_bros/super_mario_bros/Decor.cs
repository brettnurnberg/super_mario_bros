/*********************************************************************
*
*   Class:
*       Decor
*
*   Description:
*       Static list of all decoration textures
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

public static class Decor {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

static public Texture2D[]  textures;
static public Color        cloud_accent;
static public Color        bush;
static public Color        bush_accent;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       Decor
*
*   Description:
*       Constructor.
*
***********************************************************/

static Decor()
{
textures = new Texture2D[(int)decor_enum.COUNT];
cloud_accent = new Color( 60, 188, 252 );
bush = new Color( 128, 208, 16 );
bush_accent = new Color( 0, 168, 0 );
} /* Blocks() */


/***********************************************************
*
*   Method:
*       load_content
*
*   Description:
*       Loads all images for all Decor.
*
***********************************************************/

static public void load_content( ContentManager c )
{
int count = (int)decor_enum.COUNT;

for( int i = 0; i < count; i++ )
    {
    textures[i] = c.Load<Texture2D>( String.Format( "decor_" + i ) );
    }

} /* load_content() */


}
}
