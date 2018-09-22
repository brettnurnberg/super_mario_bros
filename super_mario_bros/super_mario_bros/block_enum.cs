/*********************************************************************
*
*   Class:
*       block_enum
*
*   Description:
*       Contains all types of blocks
*
*********************************************************************/

/*--------------------------------------------------------------------
                           NAMESPACE
--------------------------------------------------------------------*/

namespace super_mario_bros {

/*--------------------------------------------------------------------
                             ENUM
--------------------------------------------------------------------*/

public enum block_static_enum
{
AIR,
RED_COBBLE,
STAIR,

BLOCK_COUNT
}

public enum block_enum
{
BRICK = (int)block_static_enum.BLOCK_COUNT,

BLOCK_COUNT
}

}
