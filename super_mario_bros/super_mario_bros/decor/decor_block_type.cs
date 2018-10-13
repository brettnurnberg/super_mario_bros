/*********************************************************************
*
*   Class:
*       decor_block_type
*
*   Description:
*       Contains data for a decorative block
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

public class decor_block_type: decor_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private int texture_id;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       decor_block_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public decor_block_type( int _x, int _y, int t_id )
{
x = _x * Blocks.size.Width;
y = _y * Blocks.size.Height;
texture_id = t_id;
}


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given decoration.
*
***********************************************************/

public override void draw( SpriteBatch s )
{
Vector2 position = new Vector2( x * ViewDims.scale.X, y * ViewDims.scale.Y );
Texture2D texture = Decor.textures[texture_id];

s.Draw( texture, position, null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, (float)layer_enum.DECOR / (float)layer_enum.COUNT );

}


}
}
