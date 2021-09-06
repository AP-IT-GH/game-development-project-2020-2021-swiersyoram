﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame
{
    enum gameState
    {
        start,
        running,
        pause,
        died,
        restart,
        end

    }
    enum characterState
    {
        idle,
        running,
        jump
    }
    enum level
    {
        one,
        two
    }
}
