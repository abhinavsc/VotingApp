namespace VotingApp.Models
{
    public class Voter
    {
        public int VoterId { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; } = false;
    }
}
