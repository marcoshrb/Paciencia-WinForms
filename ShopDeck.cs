using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Foxtrot;

public class ShopDeck : CardBlock
{
    Card coronga = Card.Coronga();

    CompradoDeck compra = new();   
    public override RectangleF Rect
    {
        get
        {
            float x, y, wid, hei;

            x = Location.X;
            y = Location.Y;
            wid = 79;
            hei = 110;

            return new RectangleF(x, y, wid, hei);
        }
    }
    public override void OnMove(Point cursor)
    {
    }
    public override CompradoDeck OnSelect(Point cursor)
    {

        var ultima = this.Cards[^1];
        ultima.Visible = true;

        compra.Location = new Point(1740, 160);

        var cardsArea = new Rectangle(1740, 20, 79, 110);

        if (this.Cards.Count() > 1 && cardsArea.Contains(cursor)){


            if(compra.Cards.Count == 0){
                compra.Cards.Add(coronga);
            }

            compra.Cards.Add(ultima);

            this.Cards.Remove(ultima);

            return compra;
        }

        if (this.Cards.Count() < 2 && cardsArea.Contains(cursor)){
            
            foreach (var card in compra.Cards){
                card.Visible = false;
                this.Cards.Add(card);
            }
            compra.Cards.Clear();
            compra.Cards.Add(coronga);




            List<Card> cartasRemover = new List<Card>();

            // foreach (var card in compra.Cards){
            //     if(card != coronga){
            //         card.Visible = false;
            //         this.Cards.Add(card);
            //         cartasRemover.Add(card);    
            //     }
            // }
            
            // foreach (var card in cartasRemover){
            //     compra.Cards.Remove(card);
            // }
            
            // this.Cards.Remove(this.Cards.Last());
            // compra.Cards.Add(coronga);
            
            // compra.Cards.Clear();
            return null;
        }
        return null;
    }

    public override void Draw(Graphics g)
    {
        if (this.Cards.Count <1)
            return;
        g.DrawRectangle(Pens.Red,
            this.Rect.X, Rect.Y,
            Rect.Width, Rect.Height
        );

        Card card = Cards[Cards.Count - 1];

        var rect = new Rectangle(
            (int)Location.X,
            (int)Location.Y,
            (int)card.Size.Width,
            (int)card.Size.Height
        );

        card.Draw(g, rect);


    }

}