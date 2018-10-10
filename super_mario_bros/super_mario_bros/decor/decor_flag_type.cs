/*********************************************************************
*
*   Class:
*       decor_flag_type
*
*   Description:
*       Contains data for a flag
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

public class decor_flag_type: decor_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  int     width;
public  int     height;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       decor_flag_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public decor_flag_type( int _x, int _y )
{
x = _x;
y = _y;
width = 16;
height = 16;
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
Texture2D texture = Decor.textures[(int)decor_enum.FLAG];
Vector2 position = new Vector2( x * ViewDims.scale.X, y * ViewDims.scale.Y );

s.Draw( texture, position, null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
}


}
}
