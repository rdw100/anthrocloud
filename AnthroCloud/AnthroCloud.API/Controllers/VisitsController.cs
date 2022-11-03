using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using AnthStat.Statistics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/Visits/Patient/Visits/Measures/1
        [HttpGet("patient/visits/measures/{patientId:int}")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisitsMeasures(int patientId)
        {
            return await _context.Visits
                .Include(p => p.Patient)
                .Include(m => m.Measures)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        // GET: api/Visits/measures/1
        [HttpGet("measures/{visitId:int}")]
        public async Task<ActionResult<IEnumerable<Measure>>> GetVisitMeasures(int visitId)
        {
            return await _context.Measures
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
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            // Get patient specific data for calculation
            visit.Patient = await _context.Patients.FindAsync(visit.PatientId);
            
            /* Add measures automatically */
            var listMeasures = await GetMeasuresAsync(visit);

            foreach (Measure measure in listMeasures)
            {
                _context.Measures.Add(measure);
            }

            await _context.SaveChangesAsync();

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

        /// <summary>
        /// Retrieves the calculated scored measures for a visit.
        /// </summary>
        /// <param name="visit">The patient's visit</param>
        /// <returns>A list of score measures for a patient's visit.</returns>
        private async Task<List<Measure>> GetMeasuresAsync(Visit visit)
        {
            Outputs outputs = new();
            Age age = new(visit.Patient.DateOfBirth, visit.DateOfVisit);
            outputs.Age.Days = age.Days;
            outputs.Age.Months = age.Months;
            outputs.Age.Years = age.Years;
            outputs.Age.TotalDays = age.TotalDays;
            outputs.Age.TotalMonths = age.TotalMonths;

            Age ageClinic = new(visit.Patient.DateOfBirth, visit.DateOfVisit.AddDays(-1));
            outputs.Age.Days = ageClinic.Days;
            outputs.Age.Months = ageClinic.Months;
            outputs.Age.Years = ageClinic.Years;
            outputs.Age.TotalDays = ageClinic.TotalDays;
            outputs.Age.TotalMonths = ageClinic.TotalMonths;
            outputs.Age.AgeString = ageClinic.ToReadableString();
            outputs.SetLengthHeightAdjusted(ageClinic.Years, visit.LengthHeight, visit.Measured);

            BMI bmi = new(visit.Weight, outputs.GetLengthHeightAdjusted());
            outputs.Bmi = bmi.Bmi;

            Tuple<double, double> wfaTuple = await Stats.GetScore(
                Indicator.WeightForAge,
                visit.Weight,
                age.TotalDays,
                (Sex)visit.Patient.Sex
                );
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.WFA, Zscore=wfaTuple.Item1, Percentile= wfaTuple.Item2 });

            Tuple<double, double> muacTuple = await Stats.GetScore(
                Indicator.ArmCircumferenceForAge,
                visit.MUAC,
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.MUAC, Zscore = muacTuple.Item1, Percentile = muacTuple.Item2 });

            Tuple<double, double> bfaTuple = await Stats.GetScore(
                Indicator.BodyMassIndexForAge,
                outputs.Bmi,
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.BFA, Zscore = bfaTuple.Item1, Percentile = bfaTuple.Item2 });

            Tuple<double, double> hcaTuple = await Stats.GetScore(
                Indicator.HeadCircumferenceForAge,
                visit.HeadCircumference,
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.HCA, Zscore = hcaTuple.Item1, Percentile = hcaTuple.Item2 });

            Tuple<double, double> hfaTuple = await Stats.GetScore(
                Indicator.HeightForAge,
                outputs.GetLengthHeightAdjusted(),
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.LHFA, Zscore = hfaTuple.Item1, Percentile = hfaTuple.Item2 });

            Tuple<double, double> lfaTuple = await Stats.GetScore(
                Indicator.LengthForAge,
                outputs.GetLengthHeightAdjusted(),
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.LHFA, Zscore = lfaTuple.Item1, Percentile = lfaTuple.Item2 });

            Tuple<double, double> sfaTuple = await Stats.GetScore(
                Indicator.SubscapularSkinfoldForAge,
                visit.SubscapularSkinFold,
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.SSF, Zscore = sfaTuple.Item1, Percentile = sfaTuple.Item2 });

            Tuple<double, double> tfaTuple = await Stats.GetScore(
                Indicator.TricepsSkinfoldForAge,
                visit.TricepsSkinFold,
                age.TotalDays,
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.TSF, Zscore = tfaTuple.Item1, Percentile = tfaTuple.Item2 });

            Tuple<double, double> wfhTuple = await Stats.GetScore(
                Indicator.WeightForHeight,
                visit.Weight,
                outputs.GetLengthHeightAdjusted(),
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.WFH, Zscore = wfhTuple.Item1, Percentile = wfhTuple.Item2 });

            Tuple<double, double> wflTuple = await Stats.GetScore(
                Indicator.WeightForLength,
                visit.Weight,
                outputs.GetLengthHeightAdjusted(),
                (Sex)visit.Patient.Sex);
            outputs.Measures.Add(new Measure { VisitId = visit.VisitId, Name = GrowthTypes.WFL, Zscore = wflTuple.Item1, Percentile = wflTuple.Item2 });

            return outputs.Measures;
        }
    }
}