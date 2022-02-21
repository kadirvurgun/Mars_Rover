﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Business
    {
        public  Location Move(Location location)
        {
            switch (location.currentDirection)
            {
                case Enums.Directon.W:
                    location.X--;
                    break;
                case Enums.Directon.E:
                    location.X++;
                    break;
                case Enums.Directon.S:
                    location.Y--;
                    break;
                case Enums.Directon.N:
                    location.Y++;
                    break;
            }

            return location;
        }

        public  Enums.Directon ProcessDirection(Enums.ToDirection enums, Enums.Directon enums2)
        {
            if (enums == Enums.ToDirection.R)
            {
                switch (enums2)
                {
                    case Enums.Directon.W:
                        return Enums.Directon.N;
                        break;
                    case Enums.Directon.E:
                        return Enums.Directon.S;
                        break;
                    case Enums.Directon.S:
                        return Enums.Directon.W;
                        break;
                    case Enums.Directon.N:
                        return Enums.Directon.E;
                        break;
                    default:
                        return Enums.Directon.E;
                        break;
                }
            }
            else
            {
                switch (enums2)
                {
                    case Enums.Directon.W:
                        return Enums.Directon.S;
                        break;
                    case Enums.Directon.E:
                        return Enums.Directon.N;
                        break;
                    case Enums.Directon.S:
                        return Enums.Directon.E;
                        break;
                    case Enums.Directon.N:
                        return Enums.Directon.W;
                        break;
                    default:
                        return Enums.Directon.W;
                        break;
                }
            }
        }

    }
}
