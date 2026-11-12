using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class MedExamMailSegmentRepository : IMedExamMailSegmentRepository
    {
        private readonly DbContext _context = null;

        public MedExamMailSegmentRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<string> GetHTMLSegmentByNameAsync(string name)
        {
            var segment = await _context.MedExamMailSegments.Find(x => x.SegmentName == name).FirstOrDefaultAsync();
            return segment != null ? segment.HTMLSegment : null;
        }

    }
}
