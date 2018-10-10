/*********************************************************************
*
*   Class:
*       decor_bush_type
*
*   Description:
*       Contains data for a bush
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

public class decor_bush_type: decor_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private int count;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       decor_bush_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public decor_bush_type( int _x, int _y, int bumps )
{
x = _x;
y = _y;
count = bumps;
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
Texture2D border = Decor.textures[(int)decor_enum.CLOUD_BORDER];
Texture2D inner  = Decor.textures[(int)decor_enum.CLOUD_INNER];
Texture2D accent = Decor.textures[(int)decor_enum.CLOUD_ACCENT];
Vector2 position = new Vector2( x * ViewDims.scale.X, y * ViewDims.scale.Y );
Vector2 offset   = new Vector2( 15 * ViewDims.scale.X, 0 );

for( int i = 0; i < count; i++ )
    {
    s.Draw( border, position + ( i * offset ), null, Color.Black, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
    }
for( int i = 0; i < count; i++ )
    {
    s.Draw( inner, position + ( i * offset ), null, Decor.bush, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
    }
for( int i = 0; i < count; i++ )
    {
    s.Draw( accent, position + ( i * offset ), null, Decor.bush_accent, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
    }

}


}
}
