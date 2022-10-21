using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace AnthroCloud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly AssessmentContext _context;

        public VisitsController(AssessmentContext context)
        {
            _context = context;
        }

        // GET: api/Visits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
        {
            return await _context.Visits.ToListAsync();
        }

        // GET: api/Visits/patient/1
        [HttpGet("patient/{patientId:int}")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits(int patientId)
        {
            return await _context.Visits
                .Include(p => p.Patient)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        // GET: api/Visits/measures/1
        [HttpGet("measures/{visitId:int}")]
        public async Task<ActionResult<IEnumerable<Measure>>> GetVisitMeasures(int visitId)
        {
            return await _context.Measures
                //.Include(p => p.Patient)
                //.Include(m => m.Measures)
                .Where(x => x.VisitId == visitId)
                .ToListAsync();
        }

        // GET: api/Visits/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Visit>> GetVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);

            if (visit == null)
            {
                return NotFound();
            }

            return visit;
        }

        // PUT: api/Visits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisit(int id, Visit visit)
        {
            if (id != visit.VisitId)
            {
                return BadRequest();
            }

            _context.Entry(visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Visits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visit>> PostVisit(Visit visit)
        {
            visit.Patient = null;
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            /* START Add Measures manually */
            var listMeasures = GetMeasures(visit);

            foreach (Measure measure in listMeasures)
            {
                _context.Measures.Add(measure);
            }
            await _context.SaveChangesAsync();
            /* END Add Measures manually */

            return CreatedAtAction("GetVisit", new { id = visit.VisitId }, visit);
        }

        // DELETE: api/Visits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }

            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.VisitId == id);
        }

        private List<Measure> GetMeasures(Visit visit)
        {
            List<Measure> scores = new List<Measure>
            {
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.BFA,Percentile=37.6,Zscore=-.32},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.LHFA,Percentile=0,Zscore=-3.54},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.HCA,Percentile=0,Zscore=-3.54},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.MUAC,Percentile=0,Zscore=-3.54},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.SSF,Percentile=0,Zscore=-3.54},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.TSF,Percentile=0,Zscore=-3.54},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.WFA,Percentile=0,Zscore=-3.54},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.WFA,Percentile=.9,Zscore=-2.37},
                new Measure {VisitId=visit.VisitId,Name=GrowthTypes.WFL,Percentile=32.9,Zscore=-.44},
            };

            return scores;
        }
    }
}
