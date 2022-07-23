using Moq;

namespace DeskBooking.Core.Tests
{
    public class DeskBookingProcessorTests
    {

        private readonly DeskBookingRequest _deskBookingRequest;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;
        private readonly DeskBookingProcessor _deskBookingProcessor;
        
        public DeskBookingProcessorTests()
        {
            
            _deskBookingRequest = new DeskBookingRequest
            {
                FirstName = "Thomas",
                LastName = "Cook",
                Email = "test@abc.com"
            };

            _deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();

            _deskBookingProcessor = new DeskBookingProcessor(_deskBookingRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnValidDeskBookingResult()
        {

            var result = _deskBookingProcessor.BookDesk(_deskBookingRequest);

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldThrowArgumeNullExceptionForNullRequest()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _deskBookingProcessor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveBookDesk()
        {
            DeskBooking savedDeskBooking = null;

            //set up the mock repository
            _deskBookingRepositoryMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskbooking => savedDeskBooking = deskbooking);

            _deskBookingProcessor.BookDesk(_deskBookingRequest);

            _deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Once);

        }
    }
}