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
    public class ManageCandidatesModel : PageModel
    {
        private readonly VotingContext _context;

        public ManageCandidatesModel(VotingContext context)
        {
            _context = context;
        }

        public IList<Candidate> Candidates { get; set; }

        public async Task OnGetAsync()
        {
            Candidates = await _context.Candidates.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string candidateName)
        {
            if (!string.IsNullOrEmpty(candidateName))
            {
                var candidate = new Candidate { Name = candidateName };
                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
