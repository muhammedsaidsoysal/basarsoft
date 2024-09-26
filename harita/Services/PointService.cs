using harita.Model;
using harita.Concrete;
using harita.Abstract;
namespace harita.Services
{
    public class PointService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response<Point> Add(Point point)
        {
            if (point == null)
            {
                return Response<Point>.ErrorResponse("Invalid point data.");
            }

            var repository = _unitOfWork.Repository<Point>();
            var response = repository.Add(point);

            if (response.Succeeded)
            {
                _unitOfWork.Commit();
            }
            return response;
        }

        public Response<bool> Delete(long id)
        {
            var repository = _unitOfWork.Repository<Point>();
            var response = repository.Delete(id);

            if (response.Succeeded)
            {
                _unitOfWork.Commit();
            }
            return response;
        }
        public Response<List<Point>> GetAll()
        {
            var repository = _unitOfWork.Repository<Point>();
            return repository.GetAll();
        }

        public Response<Point> GetById(long id)
        {
            var repository = _unitOfWork.Repository<Point>();
            return repository.GetById(id);
        }

        public Response<Point> Update(long id, Point updatedPoint)
        {
            var repository = _unitOfWork.Repository<Point>();
            var pointResponse = repository.GetById(id);

            if (!pointResponse.Succeeded)
            {
                return Response<Point>.ErrorResponse("Point not found.");
            }

            var existPoint = pointResponse.Value;
            existPoint.pointx = updatedPoint.pointx;
            existPoint.pointy = updatedPoint.pointy;
            existPoint.name = updatedPoint.name;

            var updateResponse = repository.Update(id, existPoint);

            if (updateResponse.Succeeded)
            {
                _unitOfWork.Commit();
            }
            return updateResponse;
        }
    }
}
