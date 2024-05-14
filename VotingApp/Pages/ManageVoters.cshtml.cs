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
    public class ManageVotersModel : PageModel
    {
        private readonly VotingContext _context;

        public ManageVotersModel(VotingContext context)
        {
            _context = context;
        }

        public IList<Voter> Voters { get; set; }

        public async Task OnGetAsync()
        {
            Voters = await _context.Voters.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string voterName)
        {
            if (!string.IsNullOrEmpty(voterName))
            {
                var voter = new Voter { Name = voterName };
                _context.Voters.Add(voter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var voter = await _context.Voters.FindAsync(id);
            if (voter != null)
            {
                _context.Voters.Remove(voter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
