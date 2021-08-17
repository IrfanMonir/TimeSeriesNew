using AutoMapper;

using MediatR;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Readings.Query
{
    public class ReadingListHandler : IRequestHandler<ReadingList, List<ReadingsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReadingService _readingService;
        public ReadingListHandler(IReadingService readingService, IMapper mapper)
        {
            _readingService = readingService;
            _mapper = mapper;
        }
        public async Task<List<ReadingsDto>> Handle(ReadingList request, CancellationToken cancellationToken)
        {
            //Full List
            if (request.BuildingId == 0 && request.ObjectId == 0 &&
                request.DataFieldId == 0 && request.StartTime != null && request.EndTime != null)
            {
                var readings = await _readingService.GetReadingList();
                return _mapper.Map<List<ReadingsDto>>(readings);
            }

            //Filtered
            var reading2 = await _readingService.GetReadingList(request.BuildingId, request.ObjectId,
                request.DataFieldId, request.StartTime, request.EndTime);


            var res = _mapper.Map<List<ReadingsDto>>(reading2);
            return res;
        }
    }
}
