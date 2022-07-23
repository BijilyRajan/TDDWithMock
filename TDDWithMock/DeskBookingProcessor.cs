namespace DeskBooking.Core
{
    public class DeskBookingProcessor
    {
        private readonly IDeskBookingRepository _deskbookingRepository;
        


        public DeskBookingProcessor(IDeskBookingRepository deskBookingRepository)
        {
            this._deskbookingRepository = deskBookingRepository;
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _deskbookingRepository.Save(Create<DeskBooking>(request));

            return Create<DeskBookingResult>(request);

        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName 
            };
        }
    }
}