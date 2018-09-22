/*********************************************************************
*
*   Class:
*       controller_type
*
*   Description:
*       Contains the game logic
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

public class controller_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private model_type model;
private int v_idx;
private char_status_enum prev_location;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       controller_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public controller_type( model_type m )
{
model = m;
v_idx = 0;
} /* controller_type() */


/***********************************************************
*
*   Method:
*       update
*
*   Description:
*       Updates the game logic.
*       //update mario's status (for use with animations)
*       Mario seems to stop moving when hitting the ground?
*
***********************************************************/

public void update()
{
KeyBinding.set_key_states();
physics_type physics = model.level.mario.physics;
char_status_enum location;

location = model.level.mario.ground_status;

/*----------------------------------------------------------
Update mario Y location on jump
----------------------------------------------------------*/
if( location == char_status_enum.GROUND && KeyBinding.A_BTN_pressed )
    {
    physics.init_velocity.x = physics.velocity.x;
    physics.init_velocity.y = physics.velocity.y;

    if( KeyBinding.B_BTN_pressed )
        {
        physics.init_velocity.x++;
        }

    v_idx = 0;
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.y = MarioPhysics.ay_j_a[v_idx];
    physics.velocity.y     = MarioPhysics.vy_j_init[v_idx];
    }
/*----------------------------------------------------------
Update mario Y location on fall
----------------------------------------------------------*/
else if( prev_location == char_status_enum.GROUND &&
         location == char_status_enum.AIR &&
         physics.velocity.y == 0 )
    {
    physics.init_velocity.x = physics.velocity.x;
    physics.init_velocity.y = physics.velocity.y;

    if( KeyBinding.B_BTN_pressed )
        {
        physics.init_velocity.x++;
        }

    v_idx = 0;
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.y = MarioPhysics.ay_j_f[v_idx];
    physics.velocity.y += physics.acceleration.y;
    }
/*----------------------------------------------------------
Update mario Y location in air
----------------------------------------------------------*/
else if( location == char_status_enum.AIR )
    {
    if( KeyBinding.A_BTN_pressed && physics.velocity.y < 0 )
        {
        physics.acceleration.y = MarioPhysics.ay_j_a[v_idx];
        physics.velocity.y += physics.acceleration.y;
        }
    else
        {
        physics.acceleration.y = MarioPhysics.ay_j_f[v_idx];
        physics.velocity.y += physics.acceleration.y;
        }

    if( KeyBinding.D_RIGHT_pressed )
        {
        if( physics.velocity.x <= MarioPhysics.vx_walk_max )
            {
            physics.acceleration.x = MarioPhysics.ax_jf_walk;
            }
        else
            {
            physics.acceleration.x = MarioPhysics.ax_jf_run;
            }

        physics.velocity.x += physics.acceleration.x;
        }
    else if( KeyBinding.D_LEFT_pressed )
        {
        if( physics.velocity.x >= MarioPhysics.vx_walk_max )
            {
            physics.acceleration.x = MarioPhysics.ax_jb_run;
            }
        else if( ( physics.velocity.x < MarioPhysics.vx_walk_max ) &&
                 ( physics.init_velocity.x >= MarioPhysics.vx_j_thresh ) )
            {
            physics.acceleration.x = MarioPhysics.ax_jb_run_walk;
            }
        else
            {
            physics.acceleration.x = MarioPhysics.ax_jb_walk;
            }

        physics.velocity.x += physics.acceleration.x;
        }

    /*----------------------------------------------------------
    Keep speeds in bounds
    ----------------------------------------------------------*/
    if( ( physics.init_velocity.x <= MarioPhysics.vx_walk_max ) &&
        ( physics.velocity.x > MarioPhysics.vx_walk_max ) )
        {
        physics.velocity.x = MarioPhysics.vx_walk_max;
        }
    else if( ( physics.init_velocity.x >= -1 * MarioPhysics.vx_walk_max ) &&
             ( physics.velocity.x < -1 * MarioPhysics.vx_walk_max ) )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_max;
        }

    if( physics.velocity.y > MarioPhysics.vy_j_max )
        {
        physics.velocity.y = MarioPhysics.vy_j_max;
        }
    if( physics.velocity.x > MarioPhysics.vx_run_max )
        {
        physics.velocity.x = MarioPhysics.vx_run_max;
        }
    else if( physics.velocity.x < ( -1 * MarioPhysics.vx_run_max ) )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_run_max;
        }
    }
/*----------------------------------------------------------
Update mario Y location on ground
----------------------------------------------------------*/
else
    {
    physics.acceleration.y = 0;
    physics.velocity.y = 0;
    }

/*----------------------------------------------------------
Skidding left
----------------------------------------------------------*/
if( ( KeyBinding.D_RIGHT_pressed ) &&
    ( physics.velocity.x < -1 * MarioPhysics.vx_skid_thresh ) &&
    ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = MarioPhysics.ax_skid;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Skidding right
----------------------------------------------------------*/
else if( ( KeyBinding.D_LEFT_pressed ) &&
         ( physics.velocity.x > MarioPhysics.vx_skid_thresh ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = -1 * MarioPhysics.ax_skid;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Running right
----------------------------------------------------------*/
else if( KeyBinding.D_RIGHT_pressed &&
         KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    if( physics.velocity.x < 0 )
        {
        physics.velocity.x = 0;
        }

    physics.acceleration.x = MarioPhysics.ax_run;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x > MarioPhysics.vx_run_max )
        {
        physics.velocity.x = MarioPhysics.vx_run_max;
        }

    if( physics.velocity.x < MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Running left
----------------------------------------------------------*/
else if( KeyBinding.D_LEFT_pressed &&
         KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    if( physics.velocity.x > 0 )
        {
        physics.velocity.x = 0;
        }

    physics.acceleration.x = -1 * MarioPhysics.ax_run;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x < -1 * MarioPhysics.vx_run_max )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_run_max;
        }

    if( physics.velocity.x > -1 * MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Walking right
----------------------------------------------------------*/
else if( KeyBinding.D_RIGHT_pressed &&
         !KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = MarioPhysics.ax_walk;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x > MarioPhysics.vx_walk_max )
        {
        physics.velocity.x = MarioPhysics.vx_walk_max;
        }

    if( physics.velocity.x < MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Walking left
----------------------------------------------------------*/
else if( KeyBinding.D_LEFT_pressed &&
         !KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = -1 * MarioPhysics.ax_walk;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x < -1 * MarioPhysics.vx_walk_max )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_max;
        }

    if( physics.velocity.x > -1 * MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Sliding right
----------------------------------------------------------*/
else if( ( physics.velocity.x > MarioPhysics.vx_walk_min ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = -1 * MarioPhysics.ax_release;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Sliding left
----------------------------------------------------------*/
else if( ( physics.velocity.x < -1 * MarioPhysics.vx_walk_min ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = MarioPhysics.ax_release;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Standing still
----------------------------------------------------------*/
else if( location == char_status_enum.GROUND )
    {
    physics.acceleration.x = 0;
    physics.velocity.x = 0;
    }

/*----------------------------------------------------------
Handle all collisions
----------------------------------------------------------*/
update_hit_box( model.level.mario );

/*----------------------------------------------------------
Never scroll screen left
----------------------------------------------------------*/
if( physics.position.x < ViewDims.view.X )
    {
    physics.position.x = ViewDims.view.X;
    physics.acceleration.x = 0;
    physics.velocity.x = 0;
    }

} /* update() */


/***********************************************************
*
*   Method:
*       update_hit_box
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

private void update_hit_box( character_type c )
{
/*----------------------------------------------------------
Local variables
----------------------------------------------------------*/
int[] x = new int[2];
int[] y = new int[2];
int suby;

/*----------------------------------------------------------
Update y position and find character boundaries
----------------------------------------------------------*/
c.physics.position.y += c.physics.velocity.y;

x[0] = ( c.physics.position.x >> 12 ) / Blocks.size.Width;
x[1] = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width  ) / Blocks.size.Width;
y[0] = ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height;
y[1] = ( c.physics.position.y >> 12 ) / Blocks.size.Height;

prev_location = c.ground_status;

/*----------------------------------------------------------
Check for y collisions
----------------------------------------------------------*/
if( contains_block( x, y[1] ) )
    {
    push_down( c );
    }
else if( contains_block( x, y[0] ) )
    {
    push_up( c );
    }
else
    {
    c.ground_status = char_status_enum.AIR;
    }

/*----------------------------------------------------------
Update x position and find character boundaries
----------------------------------------------------------*/
c.physics.position.x += c.physics.velocity.x;

x[0] = ( c.physics.position.x >> 12 ) / Blocks.size.Width;
x[1] = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width  ) / Blocks.size.Width;
y[0] = ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height;
y[1] = ( c.physics.position.y >> 12 ) / Blocks.size.Height;
suby = ( c.physics.position.y >> 12 ) % Blocks.size.Height;

if( c.ground_status == char_status_enum.GROUND )
    {
    y[0]--;
    }

/*----------------------------------------------------------
Check for x collisions
----------------------------------------------------------*/
if( contains_block( x[0], y ) )
    {
    push_right( c );
    }
else if( contains_block( x[1], y ) )
    {
    push_left( c );
    }

} /* update_hit_box() */


/***********************************************************
*
*   Method:
*       push_down
*
*   Description:
*       Push the character down one block.
*
***********************************************************/

private void push_down( character_type c )
{
int y = ( ( c.physics.position.y >> 12 ) / Blocks.size.Height ) + 1;

c.physics.acceleration.y = 0;
c.physics.velocity.y = 0;
c.physics.position.y = ( y * Blocks.size.Height ) << 12;

c.ground_status = char_status_enum.AIR;

} /* push_down() */


/***********************************************************
*
*   Method:
*       push_up
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

public void push_up( character_type c )
{
int y    = ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height;

c.ground_status = char_status_enum.GROUND;
c.physics.position.y = ( ( ( y * Blocks.size.Height ) - c.physics.hit_box.Height ) + 1 ) << 12;

} /* push_up() */


/***********************************************************
*
*   Method:
*       push_right
*
*   Description:
*       Push the character left one block.
*
***********************************************************/

private void push_right( character_type c )
{
int x = ( c.physics.position.x >> 12 ) / Blocks.size.Width + 1;

c.physics.acceleration.x = 0;
c.physics.velocity.x = 0;
c.physics.position.x = ( x * Blocks.size.Width ) << 12;

} /* push_right() */


/***********************************************************
*
*   Method:
*       push_left
*
*   Description:
*       Push the character down one block.
*
***********************************************************/

private void push_left( character_type c )
{
int x = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width ) / Blocks.size.Width;

c.physics.acceleration.x = 0;
c.physics.velocity.x = 0;
c.physics.position.x = ( ( ( x * Blocks.size.Width ) - c.physics.hit_box.Width ) << 12 ) - 1;

} /* push_left() */


/***********************************************************
*
*   Method:
*       contains_block
*
*   Description:
*       Returns true if the given series of blocks
*       contains a solid block.
*
*   TODO:
//this method will fail when mario falls off map - access out of bounds
//call lose_life function when we try to access out of bounds
*
***********************************************************/

private Boolean contains_block( int[] x, int y )
{
Boolean result = false;

for( int i = x[0]; i <= x[1]; i++ )
    {
    check_boundary( i, y );
    if( model.level.map.blocks[i, y] != null )
        {
        result = true;
        break;
        }
    }

return result;
} /* contains_block() */

private Boolean contains_block( int x, int[] y )
{
Boolean result = false;

for( int j = y[1]; j <= y[0]; j++ )
    {
    check_boundary( x, j );
    if( model.level.map.blocks[x, j] != null )
        {
        result = true;
        break;
        }
    }

return result;
} /* contains_block() */


/***********************************************************
*
*   Method:
*       check_boundary
*
*   Description:
*       If Mario has left the map, lose a life.
*
***********************************************************/

private void check_boundary( int x, int y )
{
if( x < 0 || x >= model.level.map.width || y < 0 || y >= model.level.map.height )
    {
    model.level.mario.physics.position.x = model.level.mario.physics.init_position.x;
    model.level.mario.physics.position.y = model.level.mario.physics.init_position.y;
    model.level.mario.physics.velocity.x = 0;
    model.level.mario.physics.velocity.y = 0;
    model.level.mario.physics.acceleration.x = 0;
    model.level.mario.physics.acceleration.y = 0;
    while( true );
    }
} /* check_boundary() */

}
}
