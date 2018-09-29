/*********************************************************************
*
*   Class:
*       int_vector2_type
*
*   Description:
*       Contains the game data
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
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

public  class int_vector2_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public int x;
public int y;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       int_vector2_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public int_vector2_type()
{
x = 0;
y = 0;
} /* int_vector2_type() */


/***********************************************************
*
*   Method:
*       int_vector2_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public int_vector2_type( int _x, int _y )
{
x = _x;
y = _y;
} /* int_vector2_type() */

/***********************************************************
*
*   Method:
*       Operator Overloads
*
***********************************************************/

public static int_vector2_type operator +( int_vector2_type value1, int_vector2_type value2 )
{
return new int_vector2_type( value1.x + value2.x, value1.y + value2.y );
}

public static int_vector2_type operator -( int_vector2_type value1, int_vector2_type value2 )
{
return new int_vector2_type( value1.x - value2.x, value1.y - value2.y );
}

public static int_vector2_type operator *( int scaleFactor, int_vector2_type value )
{
return new int_vector2_type( value.x * scaleFactor, value.y * scaleFactor );
}

public static int_vector2_type operator *( int_vector2_type value, int scaleFactor )
{
return new int_vector2_type( value.x * scaleFactor, value.y * scaleFactor );
}

public static int_vector2_type operator /( int_vector2_type value, int scaleFactor )
{
return new int_vector2_type( value.x / scaleFactor, value.y / scaleFactor );
}

public static bool operator ==( int_vector2_type value1, int_vector2_type value2 )
{
return ( ( value1.x == value2.x ) && ( value1.y == value2.y ) );
}

public static bool operator !=( int_vector2_type value1, int_vector2_type value2 )
{
return ( ( value1.x != value2.x ) || ( value1.y != value2.y ) );
}

public override bool Equals( object obj )
{
int_vector2_type v;

if( obj == null || GetType() != obj.GetType() )
    {
    return false;
    }

v = (int_vector2_type)obj;
return ( x == v.x && y == v.y );
}

public override int GetHashCode()
{
return base.GetHashCode();
}

}
}
