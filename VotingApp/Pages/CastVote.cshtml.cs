using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VotingApp.Data;
using VotingApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VotingApp.Pages
{
    public class CastVoteModel : PageModel
    {
        private readonly VotingContext _context;

        public CastVoteModel(VotingContext context)
        {
            _context = context;
        }

        public IList<Candidate> Candidates { get; set; }
        public IList<Voter> Voters { get; set; }

        [BindProperty]
        public int VoterId { get; set; }

        [BindProperty]
        public int CandidateId { get; set; }

        public async Task OnGetAsync()
        {
            Candidates = await _context.Candidates.ToListAsync();
            Voters = await _context.Voters.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var voter = await _context.Voters.FindAsync(VoterId);
            if (voter == null || voter.HasVoted)
            {
                
                return RedirectToPage();
            }

            var candidate = await _context.Candidates.FindAsync(CandidateId);
            if (candidate == null)
            {
               
                return RedirectToPage();
            }

            voter.HasVoted = true;
            candidate.Votes += 1;

            await _context.SaveChangesAsync();
            return new JsonResult(new
            {
                success = true,
                candidateId = candidate.CandidateId,
                votes = candidate.Votes,
                voterId = voter.VoterId
            });
        }
    }
}
