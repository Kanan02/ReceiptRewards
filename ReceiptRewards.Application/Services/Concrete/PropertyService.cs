using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Concrete
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IEventRepository _eventRepository;
        public PropertyService(IPropertyRepository propertyRepository, IEventRepository eventRepository)
        {
            _propertyRepository = propertyRepository;
            _eventRepository = eventRepository;
        }

        public async Task<ApiValueResponse<AdditionalProperty>> GetInsta(StatisticsRequest statisticsRequest)
        {
            var result= await _propertyRepository.GetAsync(p => p.PropertyName == "InstaCount");

            if (statisticsRequest.StartDate!=null && statisticsRequest.EndDate!=null)
            {
                var res2 = await _eventRepository.GetAllAsync(e=>e.Name=="InstaClick"&& e.CreatedAt<=statisticsRequest.EndDate && e.CreatedAt >= statisticsRequest.StartDate);
                var number = 0;
                var numbers = res2.GroupBy(p => p.Name)
                           .Select(g =>
                                 g.Count()
                           )
                           .ToList();
                if (numbers!=null&& numbers.Count!=0)
                {
                    number = numbers[0];
                }
                if (statisticsRequest.StartDate > new DateTime(2024, 07, 29) ) {
                    result.PropertyValue = number.ToString();
                }
                else
                {
                    result.PropertyValue = (int.Parse(result.PropertyValue)+number).ToString();
                }
            }

            return new ApiValueResponse<AdditionalProperty>(result);
        }
        public async Task<ApiValueResponse<AdditionalProperty>> GetInstaSub()
        {
            var result = await _propertyRepository.GetAsync(p => p.PropertyName == "InstaSubCount");
            return new ApiValueResponse<AdditionalProperty>(result);
        }
        public async Task<ApiResponse> UpdateInstaAsync()
        {
            //var count = await _propertyRepository.GetAsync(p => p.PropertyName == "InstaCount");
            //count.PropertyValue = (int.Parse(count.PropertyValue)+1).ToString();
            await _eventRepository.AddAsync(new Event() { Name = "InstaClick" });
            await _eventRepository.SaveAsync();
            return new ApiResponse();
        }
    }
}
