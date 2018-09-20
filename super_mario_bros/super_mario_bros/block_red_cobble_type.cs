/*********************************************************************
*
*   Class:
*       block_red_cobble_type
*
*   Description:
*       Contains data for red cobblestone block
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

public class block_red_cobble_type: block_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       block_red_cobble_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public block_red_cobble_type()
{

} /* block_red_cobble_type() */


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given block.
*
***********************************************************/

public override void draw( SpriteBatch s, int x, int y )
{
Vector2 position = new Vector2( x * Blocks.size.Width * ViewDims.scale.X, y * Blocks.size.Height * ViewDims.scale.Y );
s.Draw( texture, position , null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
}


/***********************************************************
*
*   Method:
*       load_content
*
*   Description:
*       Loads content for the given block.
*
***********************************************************/

public override void load_content( ContentManager c )
{
texture = c.Load<Texture2D>( "block_red_cobble" );
} /* load_content() */


}
}
