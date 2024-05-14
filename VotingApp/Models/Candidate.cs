namespace VotingApp.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; } = 0;
    }
}
