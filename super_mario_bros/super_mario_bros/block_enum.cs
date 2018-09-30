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
QUESTION_LIT,
QUESTION_MID,
QUESTION_DARK,
BLOCK_HIT,
PIPE_VERTICAL_ENTRY_L,
PIPE_VERTICAL_ENTRY_R,
PIPE_VERTICAL_L,
PIPE_VERTICAL_R,
PIPE_HORIZONTAL_ENTRY_T,
PIPE_HORIZONTAL_ENTRY_B,
PIPE_HORIZONTAL_T,
PIPE_HORIZONTAL_B,
PIPE_MESH_T,
PIPE_MESH_B,

BLOCK_COUNT
}

}
