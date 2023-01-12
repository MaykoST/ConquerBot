using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class Mob
    {
        public UInt32 UID { get; set; }
        public String Name { get; set; }
        public Location Loc { get; set; }
        public Boolean Visible { get; set; }
        public DateTime LastAttack { get; set; }
        public Boolean MarkDelete { get; set; }
        public Boolean CanAttack { get; set; }
        public UInt16 HP { get; set; }
        public UInt16 QuantidadeAtaques { get; set; }
        public UInt16 QuantidadeMovimentos { get; set; }

        public Mob()
        {
            Loc = new Location();
            Visible = true;
            MarkDelete = false;
            CanAttack = true;
            QuantidadeAtaques = 0;
            QuantidadeMovimentos = 0;
        }

        public void Damage(UInt16 pDamage)
        {
            if (HP >= pDamage)
            {
                HP -= pDamage;
            }
            else
            {
                HP = 0;
                Visible = false; //Se Hp zerado, torna invisivel para o bot ignorar
            }

            LastAttack = DateTime.Now;
            CanAttack = true;
            QuantidadeAtaques++;
        }

        public Boolean UpdateLocation(UInt16 pX, UInt16 pY, Boolean pbJump)
        {
            if (this.Loc.X != pX || this.Loc.Y != pY)
            {
                this.Loc.OldX = this.Loc.X;
                this.Loc.OldY = this.Loc.Y;
            }

            if (pX > 0 && pY > 0)
            {
                this.Loc.X = pX;
                this.Loc.Y = pY;
                this.Loc.Valid = true;
                
                if (pbJump)
                {
                    this.Loc.LastJump = DateTime.Now;    
                }

                this.Visible = true;
                this.CanAttack = true;
                return true;               
            }

            return false;
        }

        public void Move(UInt32 pDir)
        {
            this.Loc.OldX = this.Loc.X;
            this.Loc.OldY = this.Loc.Y;
            this.QuantidadeMovimentos++;

            this.Loc.LastMove = DateTime.Now;
            this.Loc.Valid = true;
            this.Visible = true;
            this.CanAttack = true;

            //0 South, 1 South East, 2 West, 3 North West, 4 North, 5 North East, 6 East, 7 South East
            switch (pDir)
            {
                case 0:
                    {   //South
                        Loc.Y++;
                        break;
                    }
                case 1:
                    {   //South - East
                        Loc.Y++;
                        Loc.X--;
                        break;
                    }
                case 2:
                    {   //West                                         
                        Loc.X--;
                        break;
                    }
                case 3:
                    {   //North - West
                        Loc.Y--;
                        Loc.X--;
                        break;
                    }
                case 4:
                    {   //North
                        Loc.Y--;
                        break;
                    }
                case 5:
                    {   //North - East
                        Loc.Y--;
                        Loc.X++;
                        break;
                    }
                case 6:
                    {   //East
                        Loc.X++;
                        break;
                    }
                case 7:
                    {   //South - East
                        Loc.Y++;
                        Loc.X++;
                        break;
                    }
            }
        }
    }
}
