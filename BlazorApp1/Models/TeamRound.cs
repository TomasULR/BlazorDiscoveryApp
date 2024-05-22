
namespace BlazorApp1.Models
{
    public class TeamRound
    {
        /// <summary>
        /// cislo kola
        /// </summary>
        public int RoundNumber { get; set; }
        /// <summary>
        /// hodnoceni tymu
        /// </summary>
        public int Tym { get; set; }

        public int Presentation { get; set; }
        public int Prototype { get; set; }
        public int Idea { get; set; }
        public int Total => Idea + Presentation + Prototype + Tym;
    }
}
