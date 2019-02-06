using System;
using System.Collections.Generic;
using System.Text;

namespace Dockerize.Core
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
