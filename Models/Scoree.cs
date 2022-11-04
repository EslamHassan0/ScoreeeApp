using System;
using System.Collections.Generic;

namespace Score.Models
{
    public partial class Scoree
    {
        public int ScoreId { get; set; }
        public string Clubname { get; set; } = null!;
        public string PlanyerName { get; set; } = null!;
        public int ScRight { get; set; }
        public int ScLeft { get; set; }
        public int Forehand { get; set; }
        public int Backhand { get; set; }
        public int Total { get; set; }
        public string? Notes { get; set; }
    }
}
